using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VCReviewer.Model;

namespace VCReviewer.ViewModel
{
    public class EditConferenceViewModel:BaseViewModel
    {

        public EditConferenceViewModel(Conference conference, string name, DateTime dateEvent, string description, string location, string speaker)
        {

        }

        public Conference ConferenceInfo { get; set; }

        public DelegateCommand<Window> Save
        {
            get
            {
                return new DelegateCommand<Window>((w) =>
                {
                   

                    w?.Close();
                });
            }
        }



    }
}
