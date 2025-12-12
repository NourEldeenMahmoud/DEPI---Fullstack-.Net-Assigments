using Microsoft.AspNetCore.Mvc;

namespace S27_Developing_ASP_NET_MVC_5_Controllers.Controllers
{
    public class StudentsController : Controller
    {
        private static List<Student> students = new()
        {
            new Student { Id = 1, Name = "Ahmed", Email = "ahmed@school.com", Age = 20 },
            new Student { Id = 2, Name = "Sara", Email = "sara@school.com", Age = 19 }
        };

        public IActionResult Index()
        {
            return View(students);
        }

        public IActionResult Details(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            student.Id = students.Count + 1;
            students.Add(student);
            return RedirectToAction("Index");
        }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
    }
}

