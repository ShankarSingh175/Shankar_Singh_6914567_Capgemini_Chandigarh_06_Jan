using Microsoft.AspNetCore.Mvc;
using MiddlewareForRequestTracking.Services;

namespace MiddlewareForRequestTracking.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IRequestLogService _logService;

        public StudentsController(IRequestLogService logService)
        {
            _logService = logService;
        }

        public IActionResult Index()
        {
            var students = new List<string>
            {
                "Rahul",
                "Aman",
                "Neha",
                "Priya"
            };

            ViewBag.Students = students;
            ViewBag.Logs = _logService.GetLogs();

            return View();
        }
    }
}