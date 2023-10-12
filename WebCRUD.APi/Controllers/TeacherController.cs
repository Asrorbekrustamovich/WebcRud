using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebCRUD.application.Interfaces;
using WebCRUD.Domain.Entities;
using WebCRUD.Domain.Models;

[Route("api/[controller]")]
[ApiController]
public class TeacherController : Controller
{
    private readonly Iservice<Teacher> _iservice;
    private readonly IMapper _mapper;

    public TeacherController(Iservice<Teacher> service, IMapper mapper)
    {
        _iservice = service;
        _mapper = mapper;
    }

    [Route("GetAllTeachers"), HttpGet]
    public IActionResult Getall()
    {
        var getall = _iservice.Getall();
        IEnumerable<TeacherGetDTO> result = _mapper.Map<IEnumerable<TeacherGetDTO>>(getall);
        return Ok(result);
    }

    [HttpGet("Getbyid")]
    public IActionResult Getbyid(int id)
    {
        var user = _iservice.GetById(id);
        var result = _mapper.Map<TeacherGetDTO>(user);
        if (user != null)
        {
            return Ok(result);
        }
        return NotFound("User not found");
    }

    [HttpPost("Create")]
    public IActionResult Create(TeacherCreateDTO teacher)
    {
        Teacher teacher1 = _mapper.Map<Teacher>(teacher);
        var result = _iservice.Create(teacher1);
        var result2 = _mapper.Map<TeacherGetDTO>(result);
        return Ok(result2);
    }

    [HttpDelete("Delete")]
    public IActionResult Delete(int id)
    {
        var result = _iservice.Delete(id);
        return Ok(result);
    }

    [HttpPatch("Update")]
    public IActionResult Update(teacherUpdateDTO teacher)
    {var teacherUpt=_mapper.Map<Teacher>(teacher);
        var result = _iservice.Update(teacherUpt);
        var result2=_mapper.Map<TeacherGetDTO>(teacherUpt);
        return Ok(result2);
    }
}
