using VCReviewer.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCReviewer.ViewModel
{
    public class ItemViewModel : BaseViewModel
    {
        Item _model;

        public ItemViewModel(Item model)
        {
            _model = model;
        }

        public string Name
        {
            get => _model.Name;
            set
            {
                if (value == _model.Name) return;
                _model.Name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }
        public string CategoryName
        {
            get => _model.CategoryName;
            set
            {
                if (value == _model.CategoryName) return;
                _model.CategoryName = value;
                RaisePropertyChanged(nameof(CategoryName));
            }
        }
        public int Amount
        {
            get => _model.Amount;
            set
            {
                if (value == _model.Amount) return;
                _model.Amount = value;
                RaisePropertyChanged(nameof(Amount));
            }
        }
        public string Discription
        {
            get => _model.Discription;
            set
            {
                if (value == _model.Discription) return;
                _model.Discription = value;
                RaisePropertyChanged(nameof(Discription));
            }
        }
        public string GeoPosition
        {
            get => _model.GeoPosition;
            set
            {
                if (value == _model.GeoPosition) return;
                _model.GeoPosition = value;
                RaisePropertyChanged(nameof(GeoPosition));
            }
        }
        public DateTime PublishData
        {
            get => _model.PublishData;
            set
            {
                if (value == _model.PublishData) return;
                _model.PublishData = value;
                RaisePropertyChanged(nameof(PublishData));
            }
        }
        public ObservableCollection<string> Images { get => _model.Images; } 



    }
}
