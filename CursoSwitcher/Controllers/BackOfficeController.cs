using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CursoSwitcher.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class BackOfficeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
