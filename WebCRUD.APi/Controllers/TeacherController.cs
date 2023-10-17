using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WebCRUD.application.Interfaces;
using WebCRUD.Domain.Entities;
using WebCRUD.Domain.Models;

[Route("api/[controller]")]
[ApiController]
public class TeacherController : Controller
{
    private readonly Iservice<Teacher> _iservice;
    private readonly IMapper _mapper;
    private readonly IMemoryCache _cashe;

    public TeacherController(Iservice<Teacher> service, IMapper mapper, IMemoryCache cashe = null)
    {
        _iservice = service;
        _mapper = mapper;
        _cashe = cashe;
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
    [HttpGet("Getforcashing")]
    public IActionResult GetforCashing()
    {
        string cashekey = "Hello";
        string Cashedata = "ming your own business";
        var option = new MemoryCacheEntryOptions
        {

            Size = 4096,
            AbsoluteExpiration = DateTime.Now.AddSeconds(3),
            //SlidingExpiration = TimeSpan.FromSeconds(5),
            Priority = CacheItemPriority.Normal,
            //AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(7)
        };
        _cashe.Set(cashekey,Cashedata,option);
        string? result1=_cashe?.Get(cashekey)?.ToString();
        Thread.Sleep(4000);
        string? result3 = _cashe?.Get(cashekey)?.ToString();
        string? result2 = result3 == null ? "ooops" : result3;
        return Ok("1 "+result1+"  2"+result2);
    }
}
