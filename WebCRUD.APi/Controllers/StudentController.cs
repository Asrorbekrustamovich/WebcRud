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
        private readonly IMapper _mapper;

        public StudentController(Iservice<Student> service, IMapper mapper)
        {
            _iservice = service;
            _mapper = mapper;
        }

        [Route("GetAllStudents"), HttpGet]
        public IActionResult Getall()
        {
            var StudentList = _iservice.Getall();
            var result = _mapper.Map<IEnumerable<StudentGetDTO>>(StudentList);
            return Ok(result);
        }

        [HttpGet("Getbyid")]
        public IActionResult Getbyid(int id)
        {
            var user = _iservice.GetById(id);
            var userbyid=_mapper.Map<StudentGetDTO>(user);
            if (user != null)
            {
                return Ok(userbyid);
            }
            return NotFound("User not found");
        }

        [HttpPost("Create")]
        public IActionResult Create(StudentCreateDto StudentDTO)
        {
            Student student = _mapper.Map<Student>(StudentDTO);
            StudentGetDTO student1 = _mapper.Map<StudentGetDTO>(student);
            var result = _iservice.Create(student);
            return Ok(student1);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _iservice.Delete(id);
            return Ok(result);
        }

        [HttpPatch("Update")]
        public IActionResult Update(StudentUpdateDto Student)
        {
            Student studentToUpdate = _mapper.Map<Student>(Student);
            var result = _iservice.Update(studentToUpdate);
            return Ok(result);
        }
    }
}
