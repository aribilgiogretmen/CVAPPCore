using CVAPP.Data;
using CVAPP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace CVAPP.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController (ApplicationDbContext context)
        {

            _context = context;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user =_context.User.FirstOrDefault(r=>r.Email == model.Email && r.Password==model.Password);
                if (user != null)
                {
                    var claims = new[]
                    {
                        new Claim(ClaimTypes.Name,user.Email),
                        new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),

                        new Claim(ClaimTypes.Role,"Admin")

                    };


                    var claimsIdentity=new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties=new AuthenticationProperties { IsPersistent=model.RememberMe};

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claimsIdentity),authProperties);

                    return RedirectToAction("Index", "Dashboard");

                }

                ModelState.AddModelError(string.Empty, "Hatalı Kullanıcı Girişi");


            }

            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return View();
        }

    }
}
