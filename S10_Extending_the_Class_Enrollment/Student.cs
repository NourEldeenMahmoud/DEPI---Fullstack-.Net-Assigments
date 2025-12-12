using System;
using System.Text.RegularExpressions;

namespace ClassEnrollmentApplication
{
    /// <summary>
    /// Represents a student in the Class Enrollment Application
    /// </summary>
    public class Student
    {
        private string _firstName;
        private string _lastName;
        private DateTime _dateOfBirth;
        private string _studentId;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("First name cannot be empty.");
                _firstName = value;
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Last name cannot be empty.");
                _lastName = value;
            }
        }

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("Date of birth cannot be in the future.");
                if (DateTime.Now.Year - value.Year > 100)
                    throw new ArgumentException("Date of birth is too far in the past.");
                _dateOfBirth = value;
            }
        }

        public string StudentId
        {
            get { return _studentId; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Student ID cannot be empty.");
                if (!Regex.IsMatch(value, @"^STU\d{3}$"))
                    throw new ArgumentException("Student ID must be in format STU### (e.g., STU001).");
                _studentId = value;
            }
        }

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

        public int GetAge()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - DateOfBirth.Year;
            
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

