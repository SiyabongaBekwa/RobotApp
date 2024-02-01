using DAL.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions.Interfaces
{
    public interface ISurvivorRepository
    {
        Task AddSurvivor(Survivor survivor);
        Task <Survivor> FindSurvivorAsync(string IDNumber);
        Task<List<Survivor>> GetSurvivorsAsync();
        void UpdateSurvivor(Survivor survivor);
        Task<Survivor> GetSurvivorById(int Id);
        Task UpdateInfection(Survivor survivor);

    }
}
