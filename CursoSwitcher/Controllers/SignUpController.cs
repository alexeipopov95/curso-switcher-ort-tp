using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using CursoSwitcher.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

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
            var _dni_valid = _context.Profiles.Any(o => o.Dni.Equals(profileModel.Dni) && o.Email.Equals(profileModel.Email));
            if (ModelState.IsValid && !_dni_valid)
            {
                _context.Add(profileModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Login");
            }
            ViewData["CampusId"] = new SelectList(_context.Campus, "Id", "Name");
            ViewData["CareerId"] = new SelectList(_context.Careers, "Id", "Name");
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Name");
            TempData["Message"] = "Ya existe actualmente un usuario con ese documento o correo.";
            return View();
        }

    }
}
