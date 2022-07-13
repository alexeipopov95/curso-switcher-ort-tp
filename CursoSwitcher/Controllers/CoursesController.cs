using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CursoSwitcher.Models;
using Microsoft.AspNetCore.Authorization;

namespace CursoSwitcher.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class CoursesController : Controller
    {
        private readonly ModelContextManager _context;

        public CoursesController(ModelContextManager context)
        {
            _context = context;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            var modelContextManager = _context.Courses.Include(c => c.Career);
            return View(await modelContextManager.ToListAsync());
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }

            var coursesModel = await _context.Courses
                .Include(c => c.Career)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coursesModel == null)
            {
                return NotFound();
            }

            return View(coursesModel);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            ViewData["CareerId"] = new SelectList(_context.Careers, "Id", "Name");
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,CareerId,Visible_id,Created_at,Updated_at")] CoursesModel coursesModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coursesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CareerId"] = new SelectList(_context.Careers, "Id", "Name", coursesModel.CareerId);
            return View(coursesModel);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }

            var coursesModel = await _context.Courses.FindAsync(id);
            if (coursesModel == null)
            {
                return NotFound();
            }
            ViewData["CareerId"] = new SelectList(_context.Careers, "Id", "Name", coursesModel.CareerId);
            return View(coursesModel);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,CareerId,Visible_id,Created_at,Updated_at")] CoursesModel coursesModel)
        {
            if (id != coursesModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coursesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoursesModelExists(coursesModel.Id))
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
            ViewData["CareerId"] = new SelectList(_context.Careers, "Id", "Name", coursesModel.CareerId);
            return View(coursesModel);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }

            var coursesModel = await _context.Courses
                .Include(c => c.Career)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coursesModel == null)
            {
                return NotFound();
            }

            return View(coursesModel);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Courses == null)
            {
                return Problem("Entity set 'ModelContextManager.Courses'  is null.");
            }
            var coursesModel = await _context.Courses.FindAsync(id);
            var hasProfileRelated = _context.Profiles.Any(p => p.CourseId == id);
            if (coursesModel != null && !hasProfileRelated)
            {
                _context.Courses.Remove(coursesModel);
            } else
            {
                TempData["CannotDelete"] = "No puede borrar un curso con alumnos inscriptos en ella.";
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoursesModelExists(int id)
        {
          return (_context.Courses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
