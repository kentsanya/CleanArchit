using CleanArchit.Application.Interfases;
using CleanArchit.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
   
        private readonly ICourseService _courseService;
        private readonly ILogger<CourseController> _logger;

        public CourseController(ILogger<CourseController> logger, ICourseService courseService)
        {
            _courseService= courseService;
            _logger = logger;
        }

        [HttpGet]
        public void Get()
        {
          
        }

        [HttpPost]
        public IActionResult Post([FromBody]Course course) 
        {
            if (ModelState.IsValid) 
            {
                if(course!= null) 
                {
                    _courseService.Add(course);
                    return Ok(course);
                }
            }

            return BadRequest();
        }
    }
}