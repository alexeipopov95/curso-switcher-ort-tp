using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CursoSwitcher.Models;
using Microsoft.AspNetCore.Authorization;

namespace CursoSwitcher.Controllers
{
    [Authorize(Roles = "ADMIN, USER")]
    public class DashboardController : Controller
    {
        private readonly ModelContextManager _context;

        public DashboardController(ModelContextManager context)
        {
            _context = context;
        }

        private int getUserId()
        {
            var user_id = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            return user_id;
        }

        // GET: Dashboard
        public async Task<IActionResult> Index()
        {
            // Temporal, solo para ver el usuario / sesión.
            Console.WriteLine("Ingresó el usuario con el ID: {0}",getUserId());

            var modelContextManager = _context
                .Requests
                .Where(u => u.ProfileId.Equals(getUserId()))
                .Include(r => r.OfferedCourse)
                .Include(r => r.Profile)
                .Include(r => r.RequestedCourse);
            Console.WriteLine(modelContextManager);
            return View(await modelContextManager.ToListAsync());
        }

        // GET: Dashboard/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Requests == null)
            {
                return NotFound();
            }

            var requestsModel = await _context.Requests
                .Include(r => r.OfferedCourse)
                .Include(r => r.Profile)
                .Include(r => r.RequestedCourse)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requestsModel == null)
            {
                return NotFound();
            }

            return View(requestsModel);
        }

        // GET: Dashboard/Create
        public IActionResult Create()
        {            
            ViewData["OfferedCourseId"] = new SelectList(_context.Courses, "Id", "Name");
            ViewData["ProfileId"] = getUserId();
            ViewData["RequestedCourseId"] = new SelectList(_context.Courses, "Id", "Name");
            return View();
        }

        // POST: Dashboard/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProfileId,RequestedCourseId,OfferedCourseId,status,Visible_id,Created_at,Updated_at")] RequestsModel requestsModel)
        {
            Console.WriteLine(requestsModel.Id);
            Console.WriteLine(requestsModel.ProfileId);
            if (ModelState.IsValid)
            {
                _context.Add(requestsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OfferedCourseId"] = new SelectList(_context.Courses, "Id", "Name", requestsModel.OfferedCourseId);
            ViewData["ProfileId"] = getUserId();
            ViewData["RequestedCourseId"] = new SelectList(_context.Courses, "Id", "Name", requestsModel.RequestedCourseId);
            return View(requestsModel);
        }

        // GET: Dashboard/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Requests == null)
            {
                return NotFound();
            }

            var requestsModel = await _context.Requests
                .Include(r => r.OfferedCourse)
                .Include(r => r.Profile)
                .Include(r => r.RequestedCourse)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requestsModel == null)
            {
                return NotFound();
            }

            return View(requestsModel);
        }

        // POST: Dashboard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Requests == null)
            {
                return Problem("Entity set 'ModelContextManager.Requests'  is null.");
            }
            var requestsModel = await _context.Requests.FindAsync(id);
            if (requestsModel != null)
            {
                _context.Requests.Remove(requestsModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestsModelExists(int id)
        {
          return (_context.Requests?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
