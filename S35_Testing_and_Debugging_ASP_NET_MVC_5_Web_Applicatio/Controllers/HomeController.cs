using Microsoft.AspNetCore.Mvc;

namespace S29_Testing_and_Debugging_ASP_NET_MVC_5_Web_Applicatio.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Calculate(int a, int b, string operation)
        {
            try
            {
                int result = operation switch
                {
                    "add" => a + b,
                    "subtract" => a - b,
                    "multiply" => a * b,
                    "divide" => b != 0 ? a / b : throw new DivideByZeroException("Cannot divide by zero"),
                    _ => throw new ArgumentException("Invalid operation")
                };
                ViewBag.Result = result;
                ViewBag.A = a;
                ViewBag.B = b;
                ViewBag.Operation = operation;
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View();
        }
    }
}

