using Microsoft.AspNetCore.Mvc;

namespace S30_Structuring_ASP_NET_MVC_5_Web_Applications.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Controllers = new[] { "StudentsController", "GradesController", "HomeController" };
            ViewBag.Models = new[] { "Student", "Grade", "User" };
            ViewBag.Views = new[] { "Index", "Details", "Create", "Edit" };
            return View();
        }
    }
}

