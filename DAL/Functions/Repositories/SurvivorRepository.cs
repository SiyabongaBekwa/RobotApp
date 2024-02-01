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
    public class SurvivorRepository : ISurvivorRepository
    {
        private readonly DataContext _context;
        public SurvivorRepository(DataContext context)
        {
            _context = context;
        }
        public async Task AddSurvivor(Survivor survivor)
        {
            await _context.Survivors.AddAsync(survivor);
            await _context.SaveChangesAsync();
        }

        public async Task<Survivor> FindSurvivorAsync(string IDNumber)
        {
            return await _context.Survivors.FirstOrDefaultAsync(x => x.IDNumber == IDNumber);
        }

        public async Task<List<Survivor>> GetSurvivorsAsync()
        {
            return await _context.Survivors.ToListAsync();
        }

        public void UpdateSurvivor(Survivor survivor)
        {
            _context.Survivors.Update(survivor);
             _context.SaveChanges();
        }

        public async Task<Survivor> GetSurvivorById(int Id)
        {
            //return await Task.FromResult(_survivors.FirstOrDefault(s => s.Id == id));
            return await _context.Survivors.FirstOrDefaultAsync(x => x.Id == Id);

        }

        public async Task UpdateInfection(Survivor survivor)
        {

        }

        //public async Task<bool> ReportSurvivor()
        //{
        //    var result = await _context.Survivors.Where(x => x.Infection == true).ToListAsync();

        //    if(result.Count >= 3)
        //        return true;

        //    return false;
        //}
    }
}
