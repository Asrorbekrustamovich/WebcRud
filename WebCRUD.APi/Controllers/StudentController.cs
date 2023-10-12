using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebCRUD.application.Interfaces;
using WebCRUD.Domain.Entities;
using WebCRUD.Domain.Models;

namespace WebCRUD.APi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly Iservice<Student> _iservice;
        private readonly Iservice<Teacher> _tiservice;
        private readonly IMapper _mapper;

        public StudentController(Iservice<Student> service, IMapper mapper)
        {
            _iservice = service;
            _mapper = mapper;
        }

        [Route("GetAllStudents"), HttpGet]
        public IEnumerable<StudentGetDTO> Getall()
        {
            var students = _iservice.Getall();
            IEnumerable<StudentGetDTO> studentsgetall = _mapper.Map< IEnumerable<StudentGetDTO>>(students);
            return studentsgetall;
        }

        [HttpGet("Getbyid")]
        public IActionResult Getbyid(int id)
        {
            var user = _iservice.GetById(id);
            var result=_mapper.Map<StudentGetDTO>(user);
            if (user != null)
            {
                return Ok(result);
            }
            return NotFound("User not found");
        }

        [HttpPost("Create")]
        public IActionResult Create(StudentCreateDto StudentCreateDTO)
        {
            Student student = _mapper.Map<Student>(StudentCreateDTO);
             var result=_iservice.Create(student);
            var result2 = _mapper.Map<StudentGetDTO>(result);
            return Ok(result2);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _iservice.Delete(id);
            return Ok(result);
        }

        [HttpPatch("Update")]
        public IActionResult Update(StudentUpdateDtO Student)
        {
            var res1 = _mapper.Map<Student>(Student);
            var result = _iservice.Update(res1);
            var result2 = _mapper.Map<StudentGetDTO>(res1);
            return Ok(result2);
        }
    }
}
