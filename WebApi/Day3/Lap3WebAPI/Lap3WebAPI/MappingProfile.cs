using AutoMapper;
using Lap3WebAPI.DTOs;
using Lap3WebAPI.Models;

namespace Lap3WebAPI
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