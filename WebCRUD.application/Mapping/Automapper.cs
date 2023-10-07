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
            CreateMap<StudentCreateDto, Student>();
        }
    }
}
