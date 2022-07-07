using CursoSwitcher.Commons;
using CursoSwitcher.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace CursoSwitcher.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class BackOfficeController : Controller
    {
        private readonly ModelContextManager _context;

        public BackOfficeController(ModelContextManager context)
        {
            _context = context;
        }

        private int getRequestsByStatusAceptada() {
            return _context.Requests.Where(r => r.status.Equals(RequestStatusConstantsList.APROBADA)).ToList().Count;
        }
        private int getRequestsByStatusRechazada() {
            return _context.Requests.Where(r => r.status.Equals(RequestStatusConstantsList.RECHAZADA)).ToList().Count;
        }

        private int getRequestsByStatusPendiente() {
            return _context.Requests.Where(r => r.status.Equals(RequestStatusConstantsList.PENDIENTE)).ToList().Count;
        }

        private int getRequestsByStatusError() {
            return _context.Requests.Where(r => r.status.Equals(RequestStatusConstantsList.ERROR)).ToList().Count;
        }

        private Dictionary<string, int> dayMapper()
        {
            int sundayCounter = 0;
            int mondayCounter = 0;
            int tuesdayCounter = 0;
            int wednesdayCounter = 0;
            int thursdayCounter = 0;
            int fridayCounter = 0;
            int saturdayCounter = 0;

            DateTime today = DateTime.Now;
            var listedRequests = _context.Requests.Where(r => r.Created_at.Month >= today.Month && r.Created_at.Month < today.Month + 1).ToList();
            Dictionary<string, int> frequencyByDaysMap = new Dictionary<string, int>();
            foreach (var request in listedRequests) {
                switch (request.Created_at.DayOfWeek.ToString()) {
                    case "Sunday":
                        sundayCounter++;
                        break;
                    case "Monday":
                        mondayCounter++;
                        break;
                    case "Tuesday":
                        tuesdayCounter++;
                        break;
                    case "Wednesday":
                        wednesdayCounter++;
                        break;
                    case "Thursday":
                        thursdayCounter++;
                        break;
                    case "Friday":
                        fridayCounter++;
                        break;
                    case "Saturday":
                        saturdayCounter++;
                        break;
                }

            }

            frequencyByDaysMap.Add("Domingo", sundayCounter);
            frequencyByDaysMap.Add("Lunes", mondayCounter);
            frequencyByDaysMap.Add("Martes", tuesdayCounter);
            frequencyByDaysMap.Add("Miercoles", wednesdayCounter);
            frequencyByDaysMap.Add("Jueves", thursdayCounter);
            frequencyByDaysMap.Add("Viernes", fridayCounter);
            frequencyByDaysMap.Add("Sabado", saturdayCounter);
            return frequencyByDaysMap;
        }


        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.RequestsByStatusAceptada = getRequestsByStatusAceptada();
            ViewBag.RequestsByStatusRechazada = getRequestsByStatusRechazada();
            ViewBag.RequestsByStatusError = getRequestsByStatusError();
            ViewBag.RequestsByStatusPendiente = getRequestsByStatusPendiente();
            ViewBag.FrequencyByDayDuringTheMonth = dayMapper();

            return View();
        }
    }
}
