using DevExpress.Mvvm;
using Microsoft.Win32;
using VCReviewer.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace VCReviewer.ViewModel
{
    public class EditItemViewModel: BaseViewModel

    {
        public Item ItemInfo { get; set; }

        public DelegateCommand<Window> Save
        {
            get
            {
                return new DelegateCommand<Window>((w) =>
                {
                    //Item i = new Item {Name = "",CategoryName = ""  };

                    //MyJunkApp.ViewModel.LocatorViewModel.MainViewModel.SelectedItem = i;


                    //var vm = new EditItemViewModel
                    //{
                    //    ItemInfo = MyJunkApp.ViewModel.LocatorViewModel.MainViewModel.SelectedItem = i
                    //};
                    //w.DataContext = vm;

                    foreach (var key in ItemInfo.KeyWords)
                    {
                        if (DataBase.GetInstance().KeyWords.FirstOrDefault(s => key.Value == s) == null)
                        {
                            DataBase.GetInstance().KeyWords.Add(key.Value);
                        }
                    }



                    //File.WriteAllText("ItemsData.json", JsonConvert.SerializeObject(MyJunkApp.ViewModel.LocatorViewModel.MainViewModel.Items));

                    //MyJunkApp.ViewModel.LocatorViewModel.MainViewModel.ItemsView.Refresh();
                    //MyJunkApp.ViewModel.LocatorViewModel.MainViewModel.SelectedItem.ItemChanged();

                    w?.Close();
                });
            }
        }

        public DelegateCommand<Window> CloseAddItem
        {
            get
            {
                return new DelegateCommand<Window>((w) =>
                {
 
                    w?.Close();
                });
            }
        }

        public DelegateCommand AddKeyWord
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    ItemInfo.KeyWords.Add(new KeyWordItem(""));
                    
                });
            }
        }

        public DelegateCommand<KeyWordItem> DeleteKeyWord
        {
            get
            {
                return new DelegateCommand<KeyWordItem>((keyword) =>
                {
                    if (keyword != null)
                    {
                        ItemInfo.KeyWords.Remove(keyword);
                    }
                });
            }
        }

        public ICommand AddImage
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var opd = new OpenFileDialog();
                    opd.Multiselect = true;
                    opd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png ";
                    if (opd.ShowDialog() == true)
                    {
                        foreach (var item in opd.FileNames)
                        {
                            ItemInfo.Images.Add(item);
                        }
                    }
                });
            }
        }

        public ICommand RemoveImage
        {
            get
            {
                return new DelegateCommand<string>((image) =>
                {
                    if (image != null)
                    {
                        ItemInfo.Images.Remove(image);
                    }
                });
            }
        }



    }
}
