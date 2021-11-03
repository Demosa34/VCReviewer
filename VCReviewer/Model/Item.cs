using VCReviewer.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace VCReviewer.Model
{
    public class Item : BaseViewModel
    {

        private string _name;
        private string _categoryName;
        private int _amount;
        private string _discription;
        private string _geoPosition;
        private DateTime _publishData;
        private string _tematic;


        /// <summary>
        /// Оповищение
        /// </summary>
        public void ItemChanged()
        {
            RaisePropertyChanged(nameof(Name));
            RaisePropertyChanged(nameof(CategoryName));
            RaisePropertyChanged(nameof(Amount));
            RaisePropertyChanged(nameof(Discription));
            RaisePropertyChanged(nameof(GeoPosition));
            RaisePropertyChanged(nameof(PublishData));
            RaisePropertyChanged(nameof(Tematic));

            foreach(KeyWordItem kw in KeyWords)
            {
                kw.KeyWordChanged();
            }          
        }

        public Guid Id { get; set; }

        public string Name
        {
            get => _name;
            set
            {
                if (value == _name) return;
                if (value == "")  _name = "New";
                else _name = value;
            }
        }
        public string CategoryName
        {
            get => _categoryName;
            set
            {
                if (value == _categoryName) return;
                _categoryName = value;
            }
        }
        public int Amount
        {
            get => _amount;
            set
            {
                if (value == _amount) return;
                _amount = value;
            }
        }
        public string Discription
        {
            get => _discription;
            set
            {
                if (value == _discription) return;
                _discription = value;
            }
        }
        public string GeoPosition
        {
            get => _geoPosition;
            set
            {
                if (value == _geoPosition) return;
                _geoPosition = value;
            }
        }
        public DateTime PublishData
        {
            get => _publishData;
            set
            {
                if (value == _publishData) return;
                _publishData = value;
            }
        }
        public string Tematic
        {
            get => _tematic;
            set
            {
                if (value == _tematic) return;
                _tematic = value;
            }
        }
        [NotMapped]
        public ObservableCollection<string> Images { get; set; } = new ObservableCollection<string>();
        [NotMapped]
        public ObservableCollection<KeyWordItem> KeyWords { get; set; } = new ObservableCollection<KeyWordItem>();


    }
}
