using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CursoSwitcher.Models;

namespace CursoSwitcher.Controllers
{
    public class ProfileCourseController : Controller
    {
        private readonly ModelContextManager _context;

        public ProfileCourseController(ModelContextManager context)
        {
            _context = context;
        }

        // GET: ProfileCourse
        public async Task<IActionResult> Index()
        {
            var modelContextManager = _context.ProfileCourses.Include(p => p.Course).Include(p => p.Profile);
            return View(await modelContextManager.ToListAsync());
        }

        // GET: ProfileCourse/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProfileCourses == null)
            {
                return NotFound();
            }

            var profileModelCourseModel = await _context.ProfileCourses
                .Include(p => p.Course)
                .Include(p => p.Profile)
                .FirstOrDefaultAsync(m => m.ProfileId == id);
            if (profileModelCourseModel == null)
            {
                return NotFound();
            }

            return View(profileModelCourseModel);
        }

        // GET: ProfileCourse/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Name");
            ViewData["ProfileId"] = new SelectList(_context.Profiles, "Id", "Id");
            return View();
        }

        // POST: ProfileCourse/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProfileId,CourseId")] ProfileModelCourseModel profileModelCourseModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profileModelCourseModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Name", profileModelCourseModel.CourseId);
            ViewData["ProfileId"] = new SelectList(_context.Profiles, "Id", "Id", profileModelCourseModel.ProfileId);
            return View(profileModelCourseModel);
        }

        // GET: ProfileCourse/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProfileCourses == null)
            {
                return NotFound();
            }

            var profileModelCourseModel = await _context.ProfileCourses.FindAsync(id);
            if (profileModelCourseModel == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Name", profileModelCourseModel.CourseId);
            ViewData["ProfileId"] = new SelectList(_context.Profiles, "Id", "Id", profileModelCourseModel.ProfileId);
            return View(profileModelCourseModel);
        }

        // POST: ProfileCourse/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProfileId,CourseId")] ProfileModelCourseModel profileModelCourseModel)
        {
            if (id != profileModelCourseModel.ProfileId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profileModelCourseModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfileModelCourseModelExists(profileModelCourseModel.ProfileId))
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
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Name", profileModelCourseModel.CourseId);
            ViewData["ProfileId"] = new SelectList(_context.Profiles, "Id", "Id", profileModelCourseModel.ProfileId);
            return View(profileModelCourseModel);
        }

        // GET: ProfileCourse/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProfileCourses == null)
            {
                return NotFound();
            }

            var profileModelCourseModel = await _context.ProfileCourses
                .Include(p => p.Course)
                .Include(p => p.Profile)
                .FirstOrDefaultAsync(m => m.ProfileId == id);
            if (profileModelCourseModel == null)
            {
                return NotFound();
            }

            return View(profileModelCourseModel);
        }

        // POST: ProfileCourse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProfileCourses == null)
            {
                return Problem("Entity set 'ModelContextManager.ProfileCourses'  is null.");
            }
            var profileModelCourseModel = await _context.ProfileCourses.FindAsync(id);
            if (profileModelCourseModel != null)
            {
                _context.ProfileCourses.Remove(profileModelCourseModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfileModelCourseModelExists(int id)
        {
          return (_context.ProfileCourses?.Any(e => e.ProfileId == id)).GetValueOrDefault();
        }
    }
}
