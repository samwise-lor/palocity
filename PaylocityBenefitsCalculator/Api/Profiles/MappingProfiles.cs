using Api.Dtos;
using Api.Dtos.Dependent;
using Api.Dtos.Employee;
using Api.Models;
using AutoMapper;
using AutoMapper.Extensions.EnumMapping;

namespace Api.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Employee, Employee>();
            CreateMap<Dependent, Dependent>();
            CreateMap<Employee, GetEmployeeDto>().ReverseMap();
            CreateMap<Dependent, GetDependentDto>().ReverseMap();
            //CreateMap<Dependent, GetDependentDto>()
            //    .ForMember(d => d.Relationship, opt => opt.MapFrom(s => (Relationship) s.Relationship))
            //    .ReverseMap();
            CreateMap<SalaryResults, GetEmployeeSalaryDto>().ReverseMap();
        }
    }
}
