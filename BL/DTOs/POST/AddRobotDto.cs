using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs.POST
{
    public class AddRobotDto
    {
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public DateTimeOffset ManufacturedDate { get; set; }
        public string Category { get; set; }
    }
}
