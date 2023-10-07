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

        public StudentController(Iservice<Student> service)
        {
            _iservice = service;
        }

        [Route("GetAllStudents"), HttpGet]
        public IActionResult Getall()
        {
            return Ok(_iservice.Getall());
        }

        [HttpGet("Getbyid")]
        public IActionResult Getbyid(int id)
        {
            var user = _iservice.GetById(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound("User not found");
        }

        [HttpPost("Create")]
        public IActionResult Create(StudentCreateDto StudentDTO)
        {
            Student student = new Student()
            {
                Fullname = StudentDTO.Fullname,
                Teachers = StudentDTO.teacherids.Select(x => new Teacher
                { Id = x }).ToList()
            };
            var result = _iservice.Create(student);
            return Ok(result);
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
            Student studentToUpdate = new Student()
            {
                Fullname = Student.Fullname,
                Id = Student.Id,
                Teachers = Student.teacherids.Select(x => new Teacher { Id = x }).ToList()
            };
            var result = _iservice.Update(studentToUpdate);
            return Ok(result);
        }
    }
}
