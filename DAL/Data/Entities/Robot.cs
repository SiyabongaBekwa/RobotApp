﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.Entities
{
    public class Robot
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public DateTimeOffset ManufacturedDate { get; set; }
        public string Category { get; set; }
    }
}
