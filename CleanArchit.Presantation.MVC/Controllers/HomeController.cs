using CleanArchit.Application.Interfases;
using CleanArchit.Infrastructure.Data.Context;
using CleanArchit.Presantation.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CleanArchit.Presantation.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICourseService _courseService;
      

        public HomeController(ILogger<HomeController> logger, ICourseService courseService)
        {
            _courseService= courseService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(_courseService.GetViewCourse());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}