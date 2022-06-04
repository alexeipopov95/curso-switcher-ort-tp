using Microsoft.AspNetCore.Mvc;

namespace CursoSwitcher.Controllers
{
    public class NotAllowed : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
