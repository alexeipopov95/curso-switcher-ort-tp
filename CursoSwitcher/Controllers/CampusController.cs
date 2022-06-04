using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CursoSwitcher.Models;
using Microsoft.AspNetCore.Authorization;

namespace CursoSwitcher.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class CampusController : Controller
    {
        private readonly ModelContextManager _context;

        public CampusController(ModelContextManager context)
        {
            _context = context;
        }

        // GET: Campus
        public async Task<IActionResult> Index()
        {
              return _context.Campus != null ? 
                          View(await _context.Campus.ToListAsync()) :
                          Problem("Entity set 'ModelContextManager.Campus'  is null.");
        }

        // GET: Campus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Campus == null)
            {
                return NotFound();
            }

            var campusModel = await _context.Campus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (campusModel == null)
            {
                return NotFound();
            }

            return View(campusModel);
        }

        // GET: Campus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Campus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Visible_id,Created_at,Updated_at")] CampusModel campusModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(campusModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(campusModel);
        }

        // GET: Campus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Campus == null)
            {
                return NotFound();
            }

            var campusModel = await _context.Campus.FindAsync(id);
            if (campusModel == null)
            {
                return NotFound();
            }
            return View(campusModel);
        }

        // POST: Campus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Visible_id,Created_at,Updated_at")] CampusModel campusModel)
        {
            if (id != campusModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(campusModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CampusModelExists(campusModel.Id))
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
            return View(campusModel);
        }

        // GET: Campus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Campus == null)
            {
                return NotFound();
            }

            var campusModel = await _context.Campus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (campusModel == null)
            {
                return NotFound();
            }

            return View(campusModel);
        }

        // POST: Campus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Campus == null)
            {
                return Problem("Entity set 'ModelContextManager.Campus'  is null.");
            }
            var campusModel = await _context.Campus.FindAsync(id);
            if (campusModel != null)
            {
                _context.Campus.Remove(campusModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CampusModelExists(int id)
        {
          return (_context.Campus?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
