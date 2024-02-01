using DAL.Data;
using DAL.Data.Entities;
using DAL.Functions.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions.Repositories
{
    public class RobotRepository : IRobotRepository
    {
        private readonly DataContext _context;
        public RobotRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddRobot(Robot robot)
        {
            await _context.Robots.AddAsync(robot);
            await _context.SaveChangesAsync();
        }

        public async Task<Robot> FindRobotAsync(string Model)
        {
            return await _context.Robots.FirstOrDefaultAsync(x => x.Model == Model);
        }

        public async Task<List<Robot>> GetRobotsAsync()
        {
            return await _context.Robots.ToListAsync();
        }
    }
}
