using VCReviewer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCReviewer.Model
{
    public class KeyWordItem : BaseViewModel
    {

        private string _value;        
        public string Value
        {
            get => _value;
            set
            {
                if (value == _value) return;
                _value = value;
            }
        }

        public void KeyWordChanged()
        {
            RaisePropertyChanged(nameof(Value));
        }

        public KeyWordItem(string value)
        {
            Value = value;
            
        }

    }
}
