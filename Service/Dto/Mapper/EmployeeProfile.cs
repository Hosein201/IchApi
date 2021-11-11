using AutoMapper;
using Entities.Models;
using Service.Dto;
using System;

namespace Dto.Service.Mapper
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeDto, Employee>()
                .ForMember(source => source.Id,
                           destination => destination.MapFrom(src => Guid.Parse(src.Id)));

            CreateMap<Employee, EmployeeDto>()
                .ForMember(source => source.Id,
                           destination => destination.MapFrom(src => src.Id.ToString()));
        }
    }
}