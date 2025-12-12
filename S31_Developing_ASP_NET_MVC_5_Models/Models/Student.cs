using System.ComponentModel.DataAnnotations;

namespace S26_Developing_ASP_NET_MVC_5_Models.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Range(1, 100, ErrorMessage = "Age must be between 1 and 100")]
        public int Age { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Name) && 
                   !string.IsNullOrEmpty(Email) && 
                   Email.Contains("@") && 
                   Age > 0;
        }
    }
}

