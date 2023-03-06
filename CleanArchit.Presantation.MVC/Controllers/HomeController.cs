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

      


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}