using static CursoSwitcher.Models.RequestsModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CursoSwitcher.Models;
using Microsoft.AspNetCore.Authorization;
using CursoSwitcher.Commons;
using System.Diagnostics;

namespace CursoSwitcher.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class RequestsController : Controller
    {
        private readonly ModelContextManager _context;

        public RequestsController(ModelContextManager context)
        {
            _context = context;
        }


        private List<RequestModelMatch> generateMatchList()
        {
            List<RequestModelMatch> matchList = new List<RequestModelMatch>();

            var requesters = _context.Requests.ToList();
            var offerers = _context.Requests.ToList();
            List<string> terminalStatusList = new List<string> {
                RequestStatusConstantsList.APROBADA,
                RequestStatusConstantsList.RECHAZADA,
                RequestStatusConstantsList.ERROR,
                RequestStatusConstantsList.CANCELADO
            };


            foreach (var requester in requesters)
            {
                foreach (var offerer in offerers)
                {
                    if (!terminalStatusList.Contains(requester.status) && !terminalStatusList.Contains(offerer.status))
                    {
                        if (requester.RequestedCourseId == offerer.OfferedCourseId)
                        {
                            if (!matchList.Any(o =>
                            o.OffererId.Equals(requester.ProfileId)
                            && o.RequesterId.Equals(offerer.ProfileId)
                            ))
                            {
                                var requesterCourseName = _context.Courses.FirstOrDefault(o => o.Id.Equals(requester.RequestedCourseId)).Name;
                                var offererCourseName = _context.Courses.FirstOrDefault(o => o.Id.Equals(requester.OfferedCourseId)).Name;

                                RequestModelMatch obj = new RequestModelMatch(
                                    requester.RequestedCourseId,
                                    requester.OfferedCourseId,
                                    offerer.ProfileId,
                                    requester.ProfileId,
                                    requesterCourseName,
                                    offererCourseName
                                );
                                matchList.Add(obj);

                            }
                        }
                    }
                }
            }


            return matchList;
        }


        // GET: Requests
        public async Task<IActionResult> Index()
        {
            List<string> operationalLists = new RequestStatusConstantsList().getOperationalList();
            var modelContextManager = _context.Requests.Include(r => r.OfferedCourse).Include(r => r.Profile).Include(r => r.RequestedCourse);
            ViewBag.MatchList = generateMatchList();
            ViewBag.OperationalStatus = operationalLists;
            return View(await modelContextManager.ToListAsync());
        }

        // GET: Requests/Details/5
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

        // GET: Requests/Create
        public IActionResult Create()
        {
            ViewData["OfferedCourseId"] = new SelectList(_context.Courses, "Id", "Name");
            ViewData["ProfileId"] = new SelectList(_context.Profiles, "Id", "Name");
            ViewData["RequestedCourseId"] = new SelectList(_context.Courses, "Id", "Name");
            return View();
        }

        // POST: Requests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProfileId,RequestedCourseId,OfferedCourseId,status")] RequestsModel requestsModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(requestsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OfferedCourseId"] = new SelectList(_context.Courses, "Id", "Name", requestsModel.OfferedCourseId);
            ViewData["ProfileId"] = new SelectList(_context.Profiles, "Id", "Id", requestsModel.ProfileId);
            ViewData["RequestedCourseId"] = new SelectList(_context.Courses, "Id", "Name", requestsModel.RequestedCourseId);
            return View(requestsModel);
        }

        // GET: Requests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Requests == null)
            {
                return NotFound();
            }

            var requestsModel = await _context.Requests.FindAsync(id);
            if (requestsModel == null)
            {
                return NotFound();
            }
            RequestStatusConstantsList statusList = new RequestStatusConstantsList();
            ViewData["OfferedCourseId"] = new SelectList(_context.Courses, "Id", "Name", requestsModel.OfferedCourseId);
            ViewData["ProfileId"] = new SelectList(_context.Profiles, "Id", "Id", requestsModel.ProfileId);
            ViewData["RequestedCourseId"] = new SelectList(_context.Courses, "Id", "Name", requestsModel.RequestedCourseId);
            ViewData["RequestStatus"] = statusList.GenerateSelectListStatus();
            return View(requestsModel);
        }

        // POST: Requests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfileId,RequestedCourseId,OfferedCourseId,status,Visible_id,Created_at,Updated_at")] RequestsModel requestsModel)
        {
            if (id != requestsModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requestsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestsModelExists(requestsModel.Id))
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
            ViewData["OfferedCourseId"] = new SelectList(_context.Courses, "Id", "Name", requestsModel.OfferedCourseId);
            ViewData["ProfileId"] = new SelectList(_context.Profiles, "Id", "Id", requestsModel.ProfileId);
            ViewData["RequestedCourseId"] = new SelectList(_context.Courses, "Id", "Name", requestsModel.RequestedCourseId);
            return View(requestsModel);
        }

        // GET: Requests/Delete/5
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

        // POST: Requests/Delete/5
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

        /*
         * TAREA PARA MI
         * CREAR UN NUEVO CONTROLADOR, AL CUAL PEGARLE POR POST DESDE LA VISTA.
         * ENTONCES EL CHISTE ES QUE DESDE EL INDEX DEL REQUESTCONTROLLER MANDE EL POST AL NUEVO CONTROLADOR
         * EL NUEVO CONTROLADOR PROCESA LA REQUEST, SI ESTA TODO BIEN;
         *  - ACTUALIZA EL STATUS DE LOS USUARIOS Y REDIRIJE NUEVAMENTE AL INDEX DEL REQUESTCONTROLLER
         * SI SALE TODO MAL;
         *  - NO HACE UN CARAJO Y SOLAMENTE REDIRIJE AL INDEX DEL REQUESTCONTROLLER.
         */

    }
}
