using Microsoft.AspNetCore.Mvc;

namespace S31_Applying_Styles_to_ASP_NET_MVC_5_Web_Applications.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

