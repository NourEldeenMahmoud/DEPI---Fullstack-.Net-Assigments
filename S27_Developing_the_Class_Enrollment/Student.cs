using System;

namespace ClassEnrollmentApplication
{
    /// <summary>
    /// Represents a student in the Class Enrollment Application
    /// </summary>
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string StudentId { get; set; }

        public Student()
        {
        }

        public Student(string firstName, string lastName, DateTime dateOfBirth, string studentId)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            StudentId = studentId;
        }

        /// <summary>
        /// Calculates and returns the age of the student
        /// </summary>
        public int GetAge()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - DateOfBirth.Year;
            
            // Adjust if birthday hasn't occurred this year
            if (DateOfBirth.Date > today.AddYears(-age))
                age--;

            return age;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} (ID: {StudentId}, Age: {GetAge()})";
        }
    }
}

