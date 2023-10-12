using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCRUD.Domain.Entities;
using WebCRUD.Domain.Models;

namespace WebCRUD.application.mapping
{
    public class Addmapping : Profile
    {
       public Addmapping() 
        {
            CreateMap<StudentCreateDto, Student>()
             .ForMember(dest => dest.Teachers, opt => opt.MapFrom(src => src.teacherids.Select(x => new Teacher { Id = x })));
            CreateMap<TeacherCreateDTO, Teacher>().ForMember(dest => dest.Students, opt => opt.MapFrom(src => src.StudentIds.Select(x => new Student { Id = x })));
            CreateMap<Student, StudentGetDTO>().ForMember(dest => dest.teacherids, opt => opt.MapFrom(src => src.Teachers.Select(x => x.Id)));
            CreateMap<Teacher, TeacherGetDTO>().ForMember(dest => dest.StudentIds, opt => opt.MapFrom(src => src.Students.Select(x => x.Id)));
            CreateMap<teacherUpdateDTO, Teacher>().ForMember(dest => dest.Students, opt => opt.MapFrom(src => src.StudentIds.Select(x => new Student { Id = x })));
            CreateMap<StudentUpdateDtO, Student>().ForMember(dest => dest.Teachers, opt => opt.MapFrom(src => src.teacherids.Select(x => new Teacher { Id = x })));
           
        }
    }
}
