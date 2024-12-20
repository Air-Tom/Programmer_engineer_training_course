using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using WebAppExamJobMVC.Models;

namespace WebAppExamJobMVC.Controllers
{
    public class HomeController : Controller

    {
        private readonly ILogger<HomeController> _logger;
        private readonly StudentContext db;
        public HomeController(ILogger<HomeController> logger, StudentContext context)
        {
            _logger = logger;
            db = context;
        }

        public IActionResult Index()
        {
            var allStudents = db.Students.Include(s => s.Discipline).ToList();
            ViewBag.Students = allStudents;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
