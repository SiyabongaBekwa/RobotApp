using DAL.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions.Interfaces
{
    public interface IRobotRepository
    {
        Task AddRobot(Robot robot);
        Task<Robot> FindRobotAsync(string Model);
        Task<List<Robot>> GetRobotsAsync();
    }
}
