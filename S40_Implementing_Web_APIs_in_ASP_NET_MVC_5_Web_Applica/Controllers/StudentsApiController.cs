using Microsoft.AspNetCore.Mvc;

namespace S36_Implementing_Web_APIs_in_ASP_NET_MVC_5_Web_Applica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsApiController : ControllerBase
    {
        private static List<string> students = new() { "Ahmed", "Sara" };

        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            if (id > 0 && id <= students.Count)
                return Ok(students[id - 1]);
            return NotFound();
        }

        [HttpPost]
        public IActionResult CreateStudent([FromBody] string name)
        {
            students.Add(name);
            return CreatedAtAction(nameof(GetStudent), new { id = students.Count }, name);
        }
    }
}

