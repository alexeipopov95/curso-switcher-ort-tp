using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CursoSwitcher.Models;
using Microsoft.AspNetCore.Authorization;
using CursoSwitcher.Commons;

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

        private int? getCareerIdRelatedToUser()
        {
            int userId = getUserId();
            if (userId > 0 && userId != null) {
                return _context.Profiles.First(u => u.Id.Equals(userId)).CareerId;
            }
            return 0;
        }

        // GET: Dashboard
        public async Task<IActionResult> Index()
        {
            var modelContextManager = _context
                .Requests
                // Aqui en base al ID del usuario filtro SOLAMENTE aquellas solicitudes que le correspondan.
                .Where(u => u.ProfileId.Equals(getUserId()))
                .Include(r => r.OfferedCourse)
                .Include(r => r.Profile)
                .Include(r => r.RequestedCourse);
            return View(await modelContextManager.ToListAsync());
        }


        // GET: Dashboard/Create
        public IActionResult Create()
        {
            var userCareerId = getCareerIdRelatedToUser();
            var userId = getUserId();
            if (userCareerId != null)
            {
                ViewData["OfferedCourseId"] = new SelectList(_context.Courses.Where(u => u.CareerId == userCareerId), "Id", "Name");
                ViewData["ProfileId"] = userId;
                ViewData["RequestedCourseId"] = new SelectList(_context.Courses.Where(u => u.CareerId == userCareerId), "Id", "Name");
            } else
            {
                ViewData["OfferedCourseId"] = new SelectList(_context.Courses, "Id", "Name");
                ViewData["ProfileId"] = getUserId();
                ViewData["RequestedCourseId"] = new SelectList(_context.Courses, "Id", "Name");

            }
            return View();
        }

        // POST: Dashboard/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProfileId,RequestedCourseId,OfferedCourseId")] RequestsModel requestsModel)
        {
            var userCareerId = getCareerIdRelatedToUser();
            var userId = getUserId();

            if (ModelState.IsValid)
            {
                _context.Add(requestsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            if (userCareerId != null)
            {
                ViewData["OfferedCourseId"] = new SelectList(_context.Courses.Where(u => u.CareerId == userCareerId), "Id", "Name", requestsModel.OfferedCourseId);
                ViewData["ProfileId"] = userId;
                ViewData["RequestedCourseId"] = new SelectList(_context.Courses.Where(u => u.CareerId == userCareerId), "Id", "Name", requestsModel.RequestedCourseId);
            }
            else
            {
                ViewData["OfferedCourseId"] = new SelectList(_context.Courses, "Id", "Name", requestsModel.OfferedCourseId);
                ViewData["ProfileId"] = getUserId();
                ViewData["RequestedCourseId"] = new SelectList(_context.Courses, "Id", "Name", requestsModel.OfferedCourseId);

            }
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
                requestsModel.status = RequestStatusConstantsList.CANCELADO;
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
