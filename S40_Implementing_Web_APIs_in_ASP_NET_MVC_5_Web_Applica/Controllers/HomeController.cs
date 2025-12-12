using Microsoft.AspNetCore.Mvc;

namespace S36_Implementing_Web_APIs_in_ASP_NET_MVC_5_Web_Applica.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

