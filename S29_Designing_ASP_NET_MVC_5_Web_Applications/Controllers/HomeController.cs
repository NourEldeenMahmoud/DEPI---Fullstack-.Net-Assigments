using Microsoft.AspNetCore.Mvc;

namespace S25_Designing_ASP_NET_MVC_5_Web_Applications.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Routes = new[]
            {
                "/Students/Index",
                "/Students/Details",
                "/Grades/Index"
            };
            return View();
        }

        [Route("/custom-route")]
        public IActionResult CustomRoute()
        {
            return View();
        }
    }
}

