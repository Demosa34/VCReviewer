using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCReviewer.Model;

namespace VCReviewer.Data
{
    public static class DataWorker
    {

        /// <summary>
        /// Все конференции
        /// </summary>
        /// <returns></returns>
       // public static List<Conference> GetAllСonferences()
      //  {
           // var db = DataBaseContext.GetInstance();
            //var result = db.Conferences.ToList();
           // return result;
        //}



        //add
        public static string CreateConference(string name, DateTime dateEvent, string description, string location, string speaker)
        {
            var db = DataBaseContext.GetInstance();
            string result = "Chtoto poshlo ne tak";
            //проверяем сущесвует ли отдел
            //bool checkIsExist = db.Conferences.Any(el => el.Name == name);
              //  if (!checkIsExist)
                {
                    Conference newConference = new Conference
                    {
                        Name = name,
                        DateEvent = dateEvent,
                        Description = description,
                        Location = location,
                        Speaker = speaker

                    };
                   // db.Conferences.Add(newConference);
                    db.SaveChanges();
                    result = "Сделано!";
                }
                return result;
            
        }


        //редактирование отдел
        //public static string EditConference(Department oldDepartment, string name, DateTime dateEvent, string description, string location, string speaker)
        //{
        //    string result = "Такого отела не существует";
        //    using (ApplicationContext db = new ApplicationContext())
        //    {
        //        Department department = db.Departments.FirstOrDefault(d => d.Id == oldDepartment.Id);
        //        department.Name = newName;
        //        db.SaveChanges();
        //        result = "Сделано! Отдел " + department.Name + " изменен";
        //    }
        //    return result;
        //}




        //удаление 
        public static string DeleteConference( Conference conference)
        {
            string result = "Chtoto poshlo ne tak";
            var db = DataBaseContext.GetInstance();
            //db.Conferences.Remove(conference);
            db.SaveChanges();
           
            return  result = "Conference" + conference.Name + "Delete ";
        }

    }
}
