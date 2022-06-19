using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CursoSwitcher.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class BackOfficeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
