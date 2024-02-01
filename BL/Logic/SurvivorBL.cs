using AutoMapper;
using BL.DTOs.GET;
using BL.DTOs.POST;
using DAL.Data.Entities;
using DAL.Functions.Interfaces;
using DAL.Functions.Repositories;
using Microsoft.AspNetCore.Server.IIS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Logic
{
    public class SurvivorBL
    {
        private readonly ISurvivorRepository _repository;
        private readonly IMapper _mapper;
        public SurvivorBL(ISurvivorRepository survivorRepository, IMapper mapper)
        {
            _repository = survivorRepository;
            _mapper = mapper;
        }

        public async Task AddSurvivor(AddSurvivorDto addSurvivorDto)
        {
            if (addSurvivorDto == null) throw new Exception("Invalid Survivor");

            var survivorExists = await _repository.FindSurvivorAsync(addSurvivorDto.IDNumber);

            if (survivorExists != null) throw new Exception("Survivor Already Exists");

            var survivor = _mapper.Map<Survivor>(addSurvivorDto);

            await _repository.AddSurvivor(survivor);
        }

        public async Task<List<GetSurvivorDto>> GetSurvivorsAsync()
        {
            var survivors = await _repository.GetSurvivorsAsync();

            if (survivors == null) throw new Exception("Survivor not found");

            var result = _mapper.Map<List<GetSurvivorDto>>(survivors);

            return result;
        }

        public async Task<GetSurvivorDto> FindSurvivorAsync(string IDNumber)
        {
            var survivor = await _repository.FindSurvivorAsync(IDNumber);

            if (survivor == null) throw new Exception("Survivor not found");

            var result = _mapper.Map<GetSurvivorDto>(survivor);

            return result;
        }

        public async Task UpdateSurvivor(string IDNumber, string lastLocation)
        {
            var survivor = await _repository.FindSurvivorAsync(IDNumber);

            if (survivor == null) throw new Exception("Survivor not found");

            survivor.LastLocation = lastLocation;

            var result = _mapper.Map<Survivor>(survivor);

            _repository.UpdateSurvivor(result);
        }

        //Infected Survivors
       
        public async Task<bool> ReportInfection(string reportingSurvivorIdNumber, string reportedSurvivorIdNumber)
        {
            var reportingSurvivor = await _repository.FindSurvivorAsync(reportingSurvivorIdNumber);
            if (reportingSurvivor == null)
                throw new Exception("Reporting Survivor Not Found");

            var reportedSurvivor = await _repository.FindSurvivorAsync(reportedSurvivorIdNumber);
            if (reportedSurvivor == null)
                throw new Exception("Reported Survivor Not Found");

            reportedSurvivor.NumOfReports++;

            _repository.UpdateSurvivor(reportedSurvivor);

            if (reportedSurvivor.NumOfReports >= 3)
            {
                reportedSurvivor.Infection = true;
                _repository.UpdateSurvivor(reportedSurvivor);
            }

           
            return true; 
        }

        public async Task<GetStatisticsDto> GetStatistics()
        {
            GetStatisticsDto getStatisticsDto = new GetStatisticsDto();

            var survivors = await _repository.GetSurvivorsAsync();
            var totalSurvivors = survivors.Count;
            var infectedCount = survivors.Count(s => s.Infection);
            var nonInfectedCount = totalSurvivors - infectedCount;

            var infectedPercentage = (double)infectedCount / totalSurvivors * 100;
            var nonInfectedPercentage = (double)nonInfectedCount / totalSurvivors * 100;

            var infectedSurvivors = survivors.Where(s => s.Infection).ToList();
            var nonInfectedSurvivors = survivors.Where(s => !s.Infection).ToList();

            getStatisticsDto.InfectedPercentage = infectedPercentage;
            getStatisticsDto.NonInfectedPercentage = nonInfectedPercentage;
            getStatisticsDto.InfectedSurvivors = infectedSurvivors;
            getStatisticsDto.NonInfectedSurvivors = nonInfectedSurvivors;

            return (getStatisticsDto);
        }

        private async Task CheckForInfection(Survivor reportedSurvivor)
        {
            var survivors = await _repository.GetSurvivorsAsync();
            var infectedCount = survivors.Count(s => s.Infection);
            var threshold = 3;
            if (infectedCount >= threshold)
            {
                foreach (var survivor in survivors.Where(s => !s.Infection))
                {
                    survivor.Infection = true;
                    await _repository.UpdateInfection(survivor);
                }
            }
            else
            {
                if (reportedSurvivor.Infection)
                {
                    foreach (var survivor in survivors.Where(s => !s.Infection && s.IDNumber != reportedSurvivor.IDNumber))
                    {
                        var reportsCount = survivors.Count(s => s.Infection && s.IDNumber == survivor.IDNumber);
                        if (reportsCount >= threshold)
                        {
                            survivor.Infection = true;
                            await _repository.UpdateInfection(survivor);
                        }
                    }
                }
            }
        }

    }
}
