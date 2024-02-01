using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.Entities
{
    public class Survivor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string IDNumber { get; set; }
        public string LastLocation { get; set; }
        public string Inventory { get; set; }
        public bool Infection { get; set; }
        public int NumOfReports { get; set; }
    }
}
