using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCReviewer.Model;
using VCReviewer.ViewModel;

namespace ConfEvent.ViewModel
{
    class ConferenceViewModel:BaseViewModel
    {

        private Conference _model;


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


    }
}
