using Microsoft.AspNetCore.Mvc;

namespace S34_Controlling_Access_to_ASP_NET_MVC_5_Web_Applicatio.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.UserRole = "Student";
            return View();
        }

        public IActionResult Admin()
        {
            ViewBag.UserRole = "Teacher";
            ViewBag.Message = "Admin page - Only teachers can access";
            return View();
        }

        public IActionResult Grades()
        {
            ViewBag.Message = "Grades page - All authenticated users can access";
            return View();
        }
    }
}

