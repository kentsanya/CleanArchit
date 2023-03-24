using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text.Encodings.Web;
using System.Text;

namespace CleanArchit.Presantation.MVC.Areas.Identity.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Registeration(IdentityUser user)
        {
           
            if (ModelState.IsValid)
            {
                //Create new acount
                var result = _userManager.CreateAsync(user, "aewtwqertwqe");


                //create tokens the user
                if (result.Result.Succeeded)
                {
                   

                    var userId = await _userManager.GetUserIdAsync(user);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                      "/Account/ConfirmEmail",
                      pageHandler: null,
                      values: new { userId = userId, code = code, returnUrl = "Home/index" },
                      protocol: Request.Scheme);

                    //Custom confirmation email
                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        //Verification
                        var resulemail = await _userManager.ConfirmEmailAsync(user, code);

                        return RedirectToPage("RegisterConfirmation", new { email = user.Email });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect("Index");
                    }
                }
            }
            return View();
        }
    }
}
