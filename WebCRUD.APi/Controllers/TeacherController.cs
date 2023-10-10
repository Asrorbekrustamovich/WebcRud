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
        var forshowing=_mapper.Map< IEnumerable<TeacherGetDto>>(getall);
        return Ok(forshowing);
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
    public IActionResult Create(TeacherCreateDTO teacher)
    {
        Teacher teacher1 = _mapper.Map<Teacher>(teacher);
       
        var result = _iservice.Create(teacher1);
        return Ok(teacher);
    }

    [HttpDelete("Delete")]
    public IActionResult Delete(int id)
    {
        var result = _iservice.Delete(id);
        return Ok(result);
    }

    [HttpPatch("Update")]
    public IActionResult Update(TeacherUPdateDtO teacher)
    {
        Teacher studentUpdate = _mapper.Map<Teacher>(teacher);
        var result = _iservice.Update(studentUpdate);
        return Ok(result);
    }
}
