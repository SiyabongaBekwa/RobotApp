﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs.GET
{
    public class GetSurvivorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string IDNumber { get; set; }
        public string LastLocation { get; set; }
        public string Inventory { get; set; }
        public bool Infection { get; set; }
    }
}
