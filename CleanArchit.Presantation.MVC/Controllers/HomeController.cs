using CleanArchit.Application.Interfases;
using CleanArchit.Application.ViewModels;
using CleanArchit.Domain.Models;
using CleanArchit.Presantation.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Data.SqlClient.DataClassification;
using System.Collections;
using System.Diagnostics;

namespace CleanArchit.Presantation.MVC.Controllers
{



    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICourseService _courseService;


        public HomeController(ILogger<HomeController> logger, ICourseService courseService)
        {
            _courseService = courseService;
            _logger = logger;
        }


        public IActionResult Index()
        {
            ViewCourseModel viewCourse = new ViewCourseModel();
            viewCourse = _courseService.GetViewCourse();
            return View(viewCourse) ;
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
                _courseService.Add(course);
                _courseService.Save();
                return RedirectToAction("Index");
            }else 
            {
                string textarea = String.Empty;
                foreach (var item in ModelState) 
                {
                    if (item.Value.ValidationState==ModelValidationState.Invalid) 
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


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}