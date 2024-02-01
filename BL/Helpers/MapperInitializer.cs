using AutoMapper;
using BL.DTOs.POST;
using DAL.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Helpers
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<Survivor, AddSurvivorDto>().ReverseMap();
            CreateMap<Robot, AddRobotDto>().ReverseMap();
        }
    }
}
