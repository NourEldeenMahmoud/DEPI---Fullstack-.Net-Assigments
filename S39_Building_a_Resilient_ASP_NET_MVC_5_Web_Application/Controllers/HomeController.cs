using Microsoft.AspNetCore.Mvc;

namespace S35_Building_a_Resilient_ASP_NET_MVC_5_Web_Application.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Operation()
        {
            try
            {
                throw new Exception("Simulated error");
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Error handled: {ex.Message}";
                ViewBag.Message = "Application continues running...";
            }
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

