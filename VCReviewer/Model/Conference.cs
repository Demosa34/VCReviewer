using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCReviewer.Model
{
    public class Conference
    {
        public Conference()
        {
            Id = Guid.NewGuid();
            Name = string.Empty;
            DateEvent = DateTime.Now;
            Description = string.Empty;
            Location = string.Empty;
            Speaker = string.Empty;
        }


        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateEvent { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Speaker { get; set; }
       




    }
}
