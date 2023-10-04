using Microsoft.AspNetCore.Mvc;
using WebCRUD.application.Interfaces;
using WebCRUD.Domain.Models;

[Route("api/[controller]")]
[ApiController]
public class TeacherController : Controller
{
    private readonly Iservice<Teacher> _iservice;

    public TeacherController(Iservice<Teacher> service)
    {
      _iservice = service;
    }

    [Route("GetAllTeachers"), HttpGet]
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
    public IActionResult Create(Teacher teacher)
    {
        var result = _iservice.Create(teacher);
        return Ok(result);
    }

    [HttpDelete("Delete")]
    public IActionResult Delete(int id)
    {
        var result = _iservice.Delete(id);
        return Ok(result);
    }

    [HttpPatch("Update")]
    public IActionResult Update(Teacher teacher)
    {
        var result = _iservice.Update(teacher);
        return Ok(result);
    }
}
