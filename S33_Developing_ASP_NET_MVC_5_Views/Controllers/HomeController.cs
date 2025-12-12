using Microsoft.AspNetCore.Mvc;

namespace S28_Developing_ASP_NET_MVC_5_Views.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Message = "Welcome to MVC Views";
            ViewBag.Students = new[] { "Ahmed", "Sara", "Omar" };
            return View();
        }

        public IActionResult Details(string name)
        {
            ViewBag.Name = name;
            ViewBag.Age = 20;
            ViewBag.Email = $"{name.ToLower()}@school.com";
            return View();
        }
    }
}

