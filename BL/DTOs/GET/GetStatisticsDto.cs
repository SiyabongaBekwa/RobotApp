using DAL.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs.GET
{
    public class GetStatisticsDto
    {
        public double InfectedPercentage {  get; set; }
        public double NonInfectedPercentage { get; set; }
        public List<Survivor> InfectedSurvivors { get; set; }
        public List<Survivor> NonInfectedSurvivors { get; set; }
    }
}
