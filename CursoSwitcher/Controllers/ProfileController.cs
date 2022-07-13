using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CursoSwitcher.Models;
using Microsoft.AspNetCore.Authorization;

namespace CursoSwitcher.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class ProfileController : Controller
    {
        private readonly ModelContextManager _context;

        public ProfileController(ModelContextManager context)
        {
            _context = context;
        }

        // GET: Profile
        public async Task<IActionResult> Index()
        {
            var modelContextManager = _context.Profiles.Include(p => p.Campus).Include(p => p.Career).Include(p => p.Course);
            return View(await modelContextManager.ToListAsync());
        }

        // GET: Profile/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Profiles == null)
            {
                return NotFound();
            }

            var profileModel = await _context.Profiles
                .Include(p => p.Campus)
                .Include(p => p.Career)
                .Include(p => p.Course)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profileModel == null)
            {
                return NotFound();
            }

            return View(profileModel);
        }

        // GET: Profile/Create
        public IActionResult Create()
        {
            ViewData["CampusId"] = new SelectList(_context.Campus, "Id", "Name");
            ViewData["CareerId"] = new SelectList(_context.Careers, "Id", "Name");
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Name");
            return View();
        }

        // POST: Profile/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Last_name,Dni,Password,Email,Is_moderator,CourseId,CareerId,CampusId,Visible_id,Created_at,Updated_at")] ProfileModel profileModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profileModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CampusId"] = new SelectList(_context.Campus, "Id", "Name", profileModel.CampusId);
            ViewData["CareerId"] = new SelectList(_context.Careers, "Id", "Name", profileModel.CareerId);
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Name", profileModel.CourseId);
            return View(profileModel);
        }

        // GET: Profile/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Profiles == null)
            {
                return NotFound();
            }

            var profileModel = await _context.Profiles.FindAsync(id);
            if (profileModel == null)
            {
                return NotFound();
            }
            ViewData["CampusId"] = new SelectList(_context.Campus, "Id", "Name", profileModel.CampusId);
            ViewData["CareerId"] = new SelectList(_context.Careers, "Id", "Name", profileModel.CareerId);
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Name", profileModel.CourseId);
            return View(profileModel);
        }

        // POST: Profile/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Last_name,Dni,Password,Email,Is_moderator,CourseId,CareerId,CampusId,Visible_id,Created_at,Updated_at")] ProfileModel profileModel)
        {
            if (id != profileModel.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(profileModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfileModelExists(profileModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CampusId"] = new SelectList(_context.Campus, "Id", "Name", profileModel.CampusId);
            ViewData["CareerId"] = new SelectList(_context.Careers, "Id", "Name", profileModel.CareerId);
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Name", profileModel.CourseId);
            return View(profileModel);
        }

        // GET: Profile/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Profiles == null)
            {
                return NotFound();
            }

            var profileModel = await _context.Profiles
                .Include(p => p.Campus)
                .Include(p => p.Career)
                .Include(p => p.Course)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profileModel == null)
            {
                return NotFound();
            }

            return View(profileModel);
        }

        // POST: Profile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Profiles == null)
            {
                return Problem("Entity set 'ModelContextManager.Profiles'  is null.");
            }
            var profileModel = await _context.Profiles.FindAsync(id);
            if (profileModel != null)
            {
                _context.Profiles.Remove(profileModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfileModelExists(int id)
        {
          return (_context.Profiles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
