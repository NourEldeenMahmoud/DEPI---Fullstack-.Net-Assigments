using Microsoft.AspNetCore.Mvc;
using S26_Developing_ASP_NET_MVC_5_Models.Models;

namespace S26_Developing_ASP_NET_MVC_5_Models.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var student = new Student
            {
                Id = 1,
                Name = "Ahmed",
                Email = "ahmed@school.com",
                Age = 20
            };
            return View(student);
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message = $"Student {student.Name} created successfully!";
                return View("Index", student);
            }
            return View("Index", student);
        }
    }
}

