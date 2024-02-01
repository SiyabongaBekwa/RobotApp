using AutoMapper;
using BL.DTOs.GET;
using BL.DTOs.POST;
using DAL.Data.Entities;
using DAL.Functions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Logic
{
    public class RobotBL
    {
        private readonly IRobotRepository _repository;
        private readonly IMapper _mapper;
        public RobotBL(IRobotRepository robotRepository, IMapper mapper)
        {
            _repository = robotRepository;
            _mapper = mapper;
        }


        public async Task AddRobot(AddRobotDto addRobotDto)
        {
            if (addRobotDto == null) throw new Exception("Invalid Robot");

            var robotExists = await _repository.FindRobotAsync(addRobotDto.Model);

            if (robotExists != null) throw new Exception("Robot Already Exists");

            var robot = _mapper.Map<Robot>(addRobotDto);

            await _repository.AddRobot(robot);
        }

        public async Task<List<GetRobotDto>> GetRobotsAsync()
        {
            var robots = await _repository.GetRobotsAsync();

            if (robots == null) throw new Exception("Robot not found");

            var result = _mapper.Map<List<GetRobotDto>>(robots);

            return result;
        }

        public async Task<GetRobotDto> FindRobotAsync(string Model)
        {
            var robot = await _repository.FindRobotAsync(Model);

            if (robot == null) throw new Exception("Robot not found");

            var result = _mapper.Map<GetRobotDto>(robot);

            return result;
        }
    }
}
