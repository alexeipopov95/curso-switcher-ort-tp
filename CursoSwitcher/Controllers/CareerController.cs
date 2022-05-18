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
    public class CareerController : Controller
    {
        private readonly ModelContextManager _context;

        public CareerController(ModelContextManager context)
        {
            _context = context;
        }

        // GET: Career
        public async Task<IActionResult> Index()
        {
              return _context.Careers != null ? 
                          View(await _context.Careers.ToListAsync()) :
                          Problem("Entity set 'ModelContextManager.Careers'  is null.");
        }

        // GET: Career/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Careers == null)
            {
                return NotFound();
            }

            var careerModel = await _context.Careers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (careerModel == null)
            {
                return NotFound();
            }

            return View(careerModel);
        }

        // GET: Career/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Career/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] CareerModel careerModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(careerModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(careerModel);
        }

        // GET: Career/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Careers == null)
            {
                return NotFound();
            }

            var careerModel = await _context.Careers.FindAsync(id);
            if (careerModel == null)
            {
                return NotFound();
            }
            return View(careerModel);
        }

        // POST: Career/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] CareerModel careerModel)
        {
            if (id != careerModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(careerModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CareerModelExists(careerModel.Id))
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
            return View(careerModel);
        }

        // GET: Career/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Careers == null)
            {
                return NotFound();
            }

            var careerModel = await _context.Careers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (careerModel == null)
            {
                return NotFound();
            }

            return View(careerModel);
        }

        // POST: Career/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Careers == null)
            {
                return Problem("Entity set 'ModelContextManager.Careers'  is null.");
            }
            var careerModel = await _context.Careers.FindAsync(id);
            if (careerModel != null)
            {
                _context.Careers.Remove(careerModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CareerModelExists(int id)
        {
          return (_context.Careers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
