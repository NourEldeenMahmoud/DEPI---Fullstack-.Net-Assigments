using Microsoft.AspNetCore.Mvc;

namespace S32_Building_Responsive_Pages_in_ASP_NET_MVC_5_Web_App.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

