using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCReviewer.Model;


namespace ConfEvent.Model
{
    class DataBaseContext : DbContext
    {

        private static DataBaseContext _instanceFiled;
        private static readonly object Locker = new object();

        private DataBaseContext()
           : base("Data Source=DESKTOP-RO3H2BO\\SQLEXPRESS;Initial Catalog=VCSTest1;Integrated Security=True")
        {


        }

        //  public DbSet<Conference> Conferences { get; set; }
        public DbSet<Item> Items { get; set; }
        internal void Load()
        {
            Items.Load();
            //  Conferences.Load();

        }


        public static DataBaseContext GetInstance()
        {
            lock (Locker)
            {
                if (_instanceFiled != null) return _instanceFiled;
                //Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataBaseContext, Configuration>());
                _instanceFiled = new DataBaseContext();
                _instanceFiled.Load();
                return _instanceFiled;
            }
        }



    }
}
