using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCRUD.Domain.Entities;
using WebCRUD.Domain.Models;

namespace WebCRUD.application.Mapping
{
    public class Automapper : Profile
    {
        public Automapper()
        {
            CreateMap<StudentCreateDto, Student>().ForMember(dest => dest.Fullname, res => res.MapFrom(src => src.Fullname));
            CreateMap<TeacherCreateDTO, Teacher>().ForMember(dest => dest.Password, res => res.MapFrom(src => src.parol));
            CreateMap<StudentUpdateDto, Student>();
            CreateMap<TeacherUPdateDtO, Teacher>();
           
        }
    }
}
