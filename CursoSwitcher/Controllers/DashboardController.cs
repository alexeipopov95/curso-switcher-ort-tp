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

        private bool sameCourses(RequestsModel requestModel)
        {
            bool same = false;
            if (requestModel.OfferedCourseId == requestModel.RequestedCourseId)
            {
                same = true;
            }
            return same;
        }
        private void reloadData(int userId)
        {
            ViewData["OfferedCourseId"] = new SelectList(_context.Courses, "Id", "Name");
            ViewData["ProfileId"] = userId;
            ViewData["RequestedCourseId"] = new SelectList(_context.Courses, "Id", "Name");
        }
        private void reloadData(int userId, int? userData)
        {
            ViewData["OfferedCourseId"] = new SelectList(_context.Courses.Where(u => u.CareerId == userData), "Id", "Name");
            ViewData["ProfileId"] = userId;
            ViewData["RequestedCourseId"] = new SelectList(_context.Courses.Where(u => u.CareerId == userData), "Id", "Name");
        }
        private void reloadData(int userId, int? userData, RequestsModel requestData)
        {
            ViewData["OfferedCourseId"] = new SelectList(_context.Courses.Where(u => u.CareerId == userData), "Id", "Name", requestData.OfferedCourseId);
            ViewData["ProfileId"] = userId;
            ViewData["RequestedCourseId"] = new SelectList(_context.Courses.Where(u => u.CareerId == userData), "Id", "Name", requestData.RequestedCourseId);
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
                reloadData(userId, userCareerId);
            } else
            {
                reloadData(userId);
            }
            return View();
        }




        // POST: Dashboard/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProfileId,RequestedCourseId,OfferedCourseId")] RequestsModel requestsModel)
        {
            var userCareerId = getCareerIdRelatedToUser();
            var userId = getUserId();
            var request = _context.Requests.FirstOrDefault(
                r => r.RequestedCourseId == requestsModel.RequestedCourseId
                && r.OfferedCourseId == requestsModel.OfferedCourseId
                && r.ProfileId == getUserId()
                && !r.status.Equals(RequestStatusConstantsList.CANCELADO)
                && !r.status.Equals(RequestStatusConstantsList.RECHAZADA)
                && !r.status.Equals(RequestStatusConstantsList.ERROR)
            ) ;
            if (sameCourses(requestsModel)){
                TempData["AlreadyExists"] = "No puede realizar una solicitúd donde ambos cursos sean iguales.";
                reloadData(userId, userCareerId, requestsModel);
                return View(requestsModel);
            }

            if (request != null)
            {
                TempData["AlreadyExists"] = "Actualmente ya existe una solicitud para ese curso o la solicitúd ya fue aprobada.";
                reloadData(userId, userCareerId, requestsModel);
                return View(requestsModel);
            }

            if (ModelState.IsValid)
            {
                _context.Add(requestsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            reloadData(userId, userCareerId);
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
