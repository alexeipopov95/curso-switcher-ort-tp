using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using CursoSwitcher.Models;

namespace CursoSwitcher.Controllers
{
    public class SignUpController : Controller
    {
        private readonly ModelContextManager _context;

        public SignUpController(ModelContextManager context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewData["CampusId"] = new SelectList(_context.Campus, "Id", "Name");
            ViewData["CareerId"] = new SelectList(_context.Careers, "Id", "Name");
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("Id,Name,Last_name,Dni,Password,Email,CourseId,CareerId,CampusId")] ProfileModel profileModel)
        {
            bool userExists = _context.Profiles.Any(e => e.Email.Equals(profileModel.Email) || e.Dni.Equals(profileModel.Dni));
            if (!userExists)
            {
                _context.Add(profileModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Login");
            }
            ViewData["CampusId"] = new SelectList(_context.Campus, "Id", "Name");
            ViewData["CareerId"] = new SelectList(_context.Careers, "Id", "Name");
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Name");
            TempData["Message"] = "Ya existe actualmente una cuenta con ese correo electrónico o documento.";
            return View(profileModel);
        }

    }
}
