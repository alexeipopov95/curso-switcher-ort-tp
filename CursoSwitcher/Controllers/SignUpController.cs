using Microsoft.AspNetCore.Mvc;

namespace CursoSwitcher.Controllers
{
    public class SignUpController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(String Name, String LastName, String DNI, String Password, String Email)
        {
            return View();
        }
    }
}
