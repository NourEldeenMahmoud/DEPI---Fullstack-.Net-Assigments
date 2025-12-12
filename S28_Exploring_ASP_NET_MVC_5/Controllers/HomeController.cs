using Microsoft.AspNetCore.Mvc;

namespace S24_Exploring_ASP_NET_MVC_5.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC 5!";
            ViewBag.Description = "This demonstrates the MVC pattern: Model, View, Controller";
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Message = "About MVC Pattern";
            return View();
        }
    }
}

