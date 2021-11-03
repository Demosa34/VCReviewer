using VCReviewer.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace VCReviewer.Model
{
    public class DataBase : BaseViewModel
    {
        private static DataBase _Instance = new DataBase();

        public static DataBase GetInstance() => _Instance;

        public ObservableCollection<string> KeyWords { get; set; }

        private DataBase() 
        {
            KeyWords = File.Exists(@"c:\VKSWords.json") ? JsonConvert.DeserializeObject<ObservableCollection<string>>(File.ReadAllText(@"c:\VKSWords.json")) : new ObservableCollection<string>();
            BindingOperations.EnableCollectionSynchronization(KeyWords, new object());
            KeyWords.CollectionChanged += (s, e) =>
            {
                File.WriteAllText(@"c:\VKSWords.json", JsonConvert.SerializeObject(KeyWords));
            };

        }


    }
}
