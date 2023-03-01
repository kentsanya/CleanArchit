using Microsoft.AspNetCore.Mvc;

namespace CleanArchit.Presantation.MVC.Areas.Identity.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
