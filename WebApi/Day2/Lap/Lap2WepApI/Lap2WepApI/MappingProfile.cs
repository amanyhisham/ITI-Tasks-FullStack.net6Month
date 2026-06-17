using AutoMapper;
using Lap2WepApi.DTOs;
using Lap2WepApI.Models;

namespace Lap2WepApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentDTO>()
                .ForMember(dest => dest.DepartmentName,
                    opt => opt.MapFrom(src => src.Dept != null ? src.Dept.DeptName : null))
                .ForMember(dest => dest.SupervisorName,
                    opt => opt.MapFrom(src => src.Dept != null ? src.Dept.DeptName : null));

            CreateMap<Department, DepartmentDTO>()
                .ForMember(dest => dest.StudentCount,
                    opt => opt.MapFrom(src => src.Students.Count));

            CreateMap<StudentAddDTO, Student>();
        }
    }
}