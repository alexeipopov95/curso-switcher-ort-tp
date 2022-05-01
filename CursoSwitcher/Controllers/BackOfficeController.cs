using Microsoft.AspNetCore.Mvc;

namespace CursoSwitcher.Controllers
{
    public class BackOfficeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
