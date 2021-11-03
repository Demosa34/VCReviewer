using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VCReviewer.Command;
using VCReviewer.Data;
using VCReviewer.Model;
using VCReviewer.View;

namespace VCReviewer.ViewModel
{
   public class ConferenceViewModel : BaseViewModel
    {

        private Conference _model;

        // public ObservableCollection<Conference> Conferences
      //  private List<Conference> allConferences = DataWorker.GetAllСonferences();

       // public List<Conference> AllСonferences
       // {
          //  get { return allConferences; }
         //   set
         //   {
         //       allConferences = value;
         //       RaisePropertyChanged(nameof(AllСonferences));
         //   }
      // }


        private Conference _selectedConferece;
        public Conference SelectedConference
        {
            get => _selectedConferece;
            set
            {
                if (_selectedConferece == value) return;
                _selectedConferece = value;
                RaisePropertyChanged(nameof(SelectedConference));
            }
        }



        public ConferenceViewModel(Conference model)
        {
            _model = model;
        }

        public Guid Id
        {
            get { return _model.Id; }
            set
            {
                if (_model.Id == value) return;
                _model.Id = value;
                RaisePropertyChanged(nameof(Id));
            }
        }

        public string Name
        {
            get { return _model.Name; }
            set
            {
                if (_model.Name == value) return;
                _model.Name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }

        public DateTime DateEvent
        {
            get { return _model.DateEvent; }
            set
            {
                if (_model.DateEvent == value) return;
                _model.DateEvent = value;
                RaisePropertyChanged(nameof(DateEvent));
            }
        }
      
        public string Description
        {
            get { return _model.Description; }
            set
            {
                if (_model.Description == value) return;
                _model.Description = value;
                RaisePropertyChanged(nameof(Description));
            }
        }
        public string Location
        {
            get { return _model.Location; }
            set
            {
                if (_model.Location == value) return;
                _model.Location = value;
                RaisePropertyChanged(nameof(Location));
            }
        }
        public string Speaker
        {
            get { return _model.Speaker; }
            set
            {
                if (_model.Speaker == value) return;
                _model.Speaker = value;
                RaisePropertyChanged(nameof(Speaker));
            }
        }


        //private RelayCommand _showaddConference;
        //public RelayCommand ShowAddConference
        //{
        //    get
        //    {
        //        return _showaddConference ?? new RelayCommand(obj =>
        //        {
        //            Window wnd = obj as Window;
        //            string resultStr = "";
        //            if (DepartmentName == null || DepartmentName.Replace(" ", "").Length == 0)
        //            {
        //                SetRedBlockControll(wnd, "NameBlock");
        //            }
        //            else
        //            {
        //                resultStr = DataWorker.CreateDepartment(DepartmentName);
        //                UpdateAllDataView();

        //                ShowMessageToUser(resultStr);
        //                SetNullValuesToProperties();
        //                wnd.Close();
        //            }
        //        }
        //        );
        //    }
        //}

        public ICommand ShowAddConference
        {
            get
            {
                return new DelegateCommand<Conference>((conference) =>
                {
                    Conference c = new Conference { };
                    conference = c;
                    SelectedConference = c;

                    //Items.Add(i);
                    var w = new AddConferenceView();                  
                    w.DataContext = this;
                    w.ShowDialog();                   
                   // ItemsView.Refresh();
                    //SelectedItem.ItemChanged();
                });
            }
        }





        private RelayCommand _deleteConference;
        public RelayCommand DeleteConference
        {
            get
            {
                return _deleteConference ?? new RelayCommand(obj =>
                {
                    string resultStr = "Ничего не выбрано";
                    //если сотрудник
                    if (SelectedConference != null)
                    {
                        resultStr = DataWorker.DeleteConference(SelectedConference);
                       // UpdateAllDataView();
                    }
                   
                    //обновление
                    //SetNullValuesToProperties();
                    ShowMessageToUser(resultStr);
                }
                    );
            }
        }

        private void ShowMessageToUser(string message)
        {
            MessageView messageView = new MessageView(message);
            SetCenterPositionAndOpen(messageView);
        }
        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }

    }
}
