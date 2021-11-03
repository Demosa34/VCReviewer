using DevExpress.Mvvm;
using Microsoft.Win32;
using VCReviewer.Model;
using VCReviewer.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using VCReviewer.Data;

namespace VCReviewer.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; set; }
        public ICollectionView ItemsView { get; set; }
        public Page MainContent { get; set; }

        private Item _selectedItem;
        public Item SelectedItem
        {
            get => _selectedItem != null || Items != null ? _selectedItem : Items.First();
            set
            {
                if (value == _selectedItem) return;
                _selectedItem = value;
                RaisePropertyChanged(nameof(SelectedItem));
                RaisePropertyChanged(nameof(SearchText));
            }
        }


        private string _searchText { get; set; }
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                ItemsView.Filter = (obj) =>
                {
                    if (obj is Item item)
                    {
                        switch (SearchText.FirstOrDefault())
                        {
                            case '@': return item.KeyWords.FirstOrDefault(s => s.Value.ToLower().Contains(SearchText.Remove(0, 1).ToLower())) != null;
                            case '#': return item.CategoryName?.ToLower().Contains(SearchText.Remove(0, 1).ToLower()) == true;
                            case '!': return item.GeoPosition?.ToLower().Contains(SearchText.Remove(0, 1).ToLower()) == true;
                           

                            default: return item.Name.ToLower().Contains(SearchText.ToLower());
                        }
                    }

                    return false;
                };
                ItemsView.Refresh();
                RaisePropertyChanged(nameof(SearchText));

            }
        }
        public MainViewModel()
        {

            OverlayService.GetInstance().Show = (str) =>
            {
                OverlayService.GetInstance().Text = str;
            };

            Items = File.Exists(@"c:\VKSInfoData.json") ? JsonConvert.DeserializeObject<ObservableCollection<Item>>(File.ReadAllText(@"c:\VKSInfoData.json")) : new ObservableCollection<Item>();
            Items.CollectionChanged += (s, e) =>
            {
                File.WriteAllText(@"c:\VKSInfoData.json", JsonConvert.SerializeObject(Items));
            };
            BindingOperations.EnableCollectionSynchronization(Items, new object());
            ItemsView = CollectionViewSource.GetDefaultView(Items);

        }

        public ICommand Sort
        {
            get
            {
                return new DelegateCommand(() =>
                {


                    if (ItemsView.SortDescriptions.Count > 0)
                    {
                        ItemsView.SortDescriptions.Clear();
                    }
                    else
                    {
                        ItemsView.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
                    }
                });
            }
        }
        public ICommand DeleteItem
        {
            get
            {
                return new DelegateCommand<Item>((item) =>
                {
                    Items.Remove(item);
                    SelectedItem = Items.FirstOrDefault();

                }, (item) => item != null);
            }
        }       
        public ICommand AddItem
        {
            get
            {
                return new DelegateCommand<Item>((item) =>
                {

                    Item i = new Item {Name = "" };

                    item = i;
                    SelectedItem = i;

                    Items.Add(i); 
                    var w = new EditItemWindow();
                    
                    var vm = new EditItemViewModel
                    {
                        ItemInfo = item,
                    };
                    w.DataContext = vm;
                    w.ShowDialog();
                    File.WriteAllText(@"c:\VKSInfoData.json", JsonConvert.SerializeObject(Items));
                    var db = DataBaseContext.GetInstance();
                    db.Items.Add(i);
                    db.SaveChanges();
                  
                    ItemsView.Refresh();
                    SelectedItem.ItemChanged();                  
                });
            }
        }

        public ICommand AddItem1
        {
            get
            {
                return new DelegateCommand<Item>((item) =>
                {

                    //Item i = new Item { };

                    //item = i;
                    //SelectedItem = i;

                    //Items.Add(i); 
                    var w = new EditItemWindow();

                    //var vm = new EditItemViewModel
                    //{
                    //    ItemInfo = item,
                    //};
                    //w.DataContext = vm;
                    w.ShowDialog();
                   // File.WriteAllText("ItemsData.json", JsonConvert.SerializeObject(Items));

                    //ItemsView.Refresh();
                    //SelectedItem.ItemChanged();
                });
            }
        }





        public ICommand EditItem
        {
            get
            {
                return new DelegateCommand<Item>((item) =>
                {
                    var w = new EditItemWindow();
                    var vm = new EditItemViewModel
                    {
                        ItemInfo = item,
                    };
                    w.DataContext = vm;
                    w.ShowDialog();
                    File.WriteAllText(@"c:\VKSInfoData.json", JsonConvert.SerializeObject(Items));

                    ItemsView.Refresh();
                    SelectedItem.ItemChanged();

                }, (item) => item != null);
            }
        }
        public ICommand OpenImage
        {
            get
            {
                return new DelegateCommand<string>((image) =>
                {
                    if (image != null)
                    {
                        var iv = new ImageViewer()
                        {
                            DataContext = new ImageViewerViewModel
                            {
                                Image = image
                            }
                        };
                        iv.ShowDialog();
                    }
                });
            }
        }
        public ICommand TematicClick
        {
            get
            {
                return new DelegateCommand<string>((tematic) =>
                {
                    if (tematic != null)
                    {
                        SearchText = "#" + tematic;
                    }
                });
            }
        }
        public ICommand KeyWordClick
        {
            get
            {
                return new DelegateCommand<KeyWordItem>((word) =>
                {
                    if (word != null)
                    {
                        SearchText = "@" + word.Value;
                    }
                });
            }
        }
        public ICommand ChannelClick
        {
            get
            {
                return new DelegateCommand<string>((channel) =>
                {
                    if (channel != null)
                    {
                        SearchText = "!" + channel;
                    }
                });
            }
        }
        public ICommand DataClick
        {
            get
            {
                return new DelegateCommand<DateTime>((date) =>
                {
                    SearchText = "$" + date.Date.ToShortDateString();

                });
            }
        }



    }
}
