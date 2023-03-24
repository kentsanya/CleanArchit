using CleanArchit.Application.Interfases;
using CleanArchit.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CleanArchit.Presantation.MVC.Controllers
{

    [Authorize]
    public class CourseController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICourseService _courseService;


        public CourseController(ILogger<HomeController> logger, ICourseService courseService)
        {
            _courseService = courseService;
            _logger = logger;
        }


        [HttpGet]
        public IActionResult DetailCourse(int? id)
        {
            
             
            if (id > 0)
            {
                var course = _courseService.FindById(id.Value);
                if (course != null)
                {
                    return View(course);
                }
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult CreateCourse()
        {
            return View();
        }



        [HttpPost]
        public IActionResult CreateCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                List<Student> students = new List<Student>()
                {
                    new Student (){ Name="Ivan"},
                    new Student() {Name="Vova"}
                };
                course.Students.AddRange(students);
                _courseService.Add(course);
                _courseService.Save();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                string textarea = String.Empty;
                foreach (var item in ModelState)
                {
                    if (item.Value.ValidationState == ModelValidationState.Invalid)
                    {
                        textarea += item.Key;
                        foreach (var erorr in item.Value.Errors)
                        {
                            textarea += "---";
                            textarea += erorr.ErrorMessage;
                        }
                    }

                }
                return BadRequest(textarea);
            }


        }
        [HttpGet]
        public IActionResult EditCourse(int id)
        {
            if (id != 0)
            {
                var course = _courseService.FindById(id);
                if (course != null)
                {
                    return View(course);
                }
                else return NotFound();
            }
            else return NotFound();
        }
        [HttpPost]
        public IActionResult EditCourse(Course course)
        {
            if (course != null)
            {
                if (_courseService.UpDate(course))
                {
                    _courseService.Save();
                    return RedirectToAction("Index");
                }
                else return NotFound();
            }
            else return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCourse(int? id)
        {
            if (id != 0)
            {

                var course = _courseService.FindById(id.Value);
                if (course != null)
                {
                    _courseService.Remove(course);
                    await _courseService.SaveAsync();
                    return RedirectToAction("Index", "Home");
                }
                else return NotFound();
            }
            else return NotFound();
        }
    }
}
