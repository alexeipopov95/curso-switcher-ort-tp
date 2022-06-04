using Microsoft.AspNetCore.Mvc;
using CursoSwitcher.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace CursoSwitcher.Controllers
{
    public class LoginController : Controller
    {
        private readonly ModelContextManager _context;

        public LoginController(ModelContextManager context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // Método donde vamos a setear las cookies al momento de iniciar sesión.
        private ClaimsPrincipal SetCookies(ProfileModel entity)
        {
            ClaimsIdentity identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.Name, entity.Name));
            identity.AddClaim(new Claim(ClaimTypes.Role, entity.Is_moderator ? "ADMIN" : "USER"));
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, entity.Id.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.GivenName, entity.Name));

            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            return principal;
        }

        private bool UserValidation(String dni, String password)
        {
            bool loged = false;
            var user = _context.Profiles.SingleOrDefault(o => o.Dni.Equals(dni) && o.Password.Equals(password));

            if (user != null) {
                ClaimsPrincipal cookie = SetCookies(user);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, cookie).Wait();
                loged = true;
            }
            return loged;
        }


        [HttpPost]
        public IActionResult Index(String dni, String password)
        {
            if (UserValidation(dni, password))
            {
                TempData["Message"] = "Inicio de sesión correcto.";
                return RedirectToAction("Index", "Dashboard");
            } else
            {
                TempData["Message"] = "No se encontró al alumno, verifique sus credenciales.";
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
