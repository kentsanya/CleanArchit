using CleanArchit.Application.Interfases;
using CleanArchit.Presantation.MVC.Models;
using CleanArchit.Presantation.MVC.Models.Operations;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

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


        public IActionResult Index(string name, int page = 1, SortState sortState = SortState.NameAsc)
        {

            const int pageSizeElement = 3;
            var viewCourse = _courseService.GetViewCourse();

            //filter
            if (!string.IsNullOrEmpty(name)) 
            {
                viewCourse.Courses=viewCourse.Courses.Where(c => c.Name == name);
            }
            
         
            //sort
            viewCourse.Courses = sortState switch
            {
                SortState.NameDesc => viewCourse.Courses.OrderByDescending(c => c.Name),
                SortState.AuthorAsc => viewCourse.Courses.OrderBy(c => c.Author),
                SortState.AuthorDesc => viewCourse.Courses.OrderByDescending(c => c.Author),
                SortState.PriceAsc => viewCourse.Courses.OrderBy(c => c.Price),
                SortState.PriceDesc => viewCourse.Courses.OrderByDescending(c => c.Price),
                _ => viewCourse.Courses.OrderBy(c => c.Author),
            };

            //pagination
            var count=viewCourse.Courses.Count();
            var items=viewCourse.Courses.Skip((page-1)*pageSizeElement).Take(pageSizeElement).ToList();

            IndexViewModel indexViewModel = new IndexViewModel(items,
                new SortViewModel(sortState),
                new FilterViewModel(items, name),
                new PaginationViewModel(count, page, pageSizeElement));
              
            return View(indexViewModel) ;
        }

        [HttpGet]
        public IActionResult Login() 
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginView login)
        {
            
            if (login != null) 
            {
                var claims=new List<Claim> 
                {
                    new Claim(ClaimTypes.Name, login.Name),
                };
                ClaimsIdentity claimsIdentity=new ClaimsIdentity(claims, "Cookies");

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            }
            return RedirectToAction("CreateCourse","Course");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}