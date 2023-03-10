using CleanArchit.Application.Interfases;
using CleanArchit.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        

        [HttpPost]
        public IActionResult Post([FromBody] Course course)
        {
            _courseService.Add(course);
            _courseService.Save();
            return Ok(course);
        }
    }
}