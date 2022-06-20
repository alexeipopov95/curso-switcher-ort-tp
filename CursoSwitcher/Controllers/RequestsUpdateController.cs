using CursoSwitcher.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CursoSwitcher.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class RequestsUpdateController : Controller
    {
        private readonly ModelContextManager _context;

        public RequestsUpdateController(ModelContextManager context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Requests");
        }

        [HttpPost]
        public IActionResult Index(int reqId, string reqCourseName, int offeId, string offeCourseName, string operation)
        {
            // Ready player one
            var firstUserRequest = _context.Requests.FirstOrDefault(
                r => r.ProfileId.Equals(reqId)
                && r.RequestedCourse.Name == reqCourseName
                && r.OfferedCourse.Name == offeCourseName
            );
            var seccondUserRequest = _context.Requests.FirstOrDefault(
                r => r.ProfileId.Equals(offeId)
                && r.OfferedCourse.Name == reqCourseName
                && r.RequestedCourse.Name == offeCourseName
            );

            firstUserRequest.status = operation;
            seccondUserRequest.status = operation;
            _context.SaveChanges();
            return RedirectToAction("Index", "Requests");
        }
    }
}
