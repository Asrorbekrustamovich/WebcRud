using Microsoft.AspNetCore.Mvc;
using WebCRUD.application.Interfaces;
using WebCRUD.Domain.Models;

[Route("api/[controller]")]
[ApiController]
public class HomeController : Controller
{
    private readonly Iservice<User> _iservice;

    public HomeController(Iservice<User> service)
    {
        _iservice = service;
    }

    [Route("GetAllCars"), HttpGet]
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
    public IActionResult Create(User user)
    {
        var result = _iservice.Create(user);
        return Ok(result);
    }

    [HttpDelete("Delete")]
    public IActionResult Delete(int id)
    {
        var result = _iservice.Delete(id);
        return Ok(result);
    }

    [HttpPatch("Update")]
    public IActionResult Update(User user)
    {
        var result = _iservice.Update(user);
        return Ok(result);
    }
}
