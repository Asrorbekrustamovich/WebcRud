using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using StackExchange.Redis;
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
        private readonly IDistributedCache _redis;

        public StudentController(Iservice<Student> service, IMapper mapper,IDistributedCache distributedCache)
        {
            _iservice = service;
            _mapper = mapper;
            _redis = distributedCache;
        }
        [ResponseCache(Duration =30)]
        [Route("GetAllStudents"), HttpGet]
        public IEnumerable<StudentGetDTO> Getall()
        {
            string? allstudent = _redis.GetString("Pupil");
            IEnumerable<StudentGetDTO>? newallstudent;

            if (allstudent == null)
            {
                var s = _iservice.Getall();
                newallstudent = _mapper.Map<IEnumerable<StudentGetDTO>>(s);
                var option = new DistributedCacheEntryOptions()
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(10),
                    SlidingExpiration = TimeSpan.FromSeconds(10)
                };
                string converting = JsonConvert.SerializeObject(newallstudent);
                _redis.SetString("Pupil", converting, option);
            }
            else
            {
                newallstudent = JsonConvert.DeserializeObject<IEnumerable<StudentGetDTO>>(allstudent);
            }
            return newallstudent;
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
