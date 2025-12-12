using System;
using System.Collections.Generic;

namespace ExtendedEnrollment
{
    class Program
    {
        static List<Student> students = new List<Student>();
        
        static void Main(string[] args)
        {
            Console.WriteLine("=== Extended Class Enrollment Application ===\n");
            
            students.Add(new Student("Ahmed", "Ali", "ahmed@school.com", new DateTime(2010, 5, 15)));
            students.Add(new Student("Sara", "Mohamed", "sara@school.com", new DateTime(2011, 8, 20)));
            
            bool running = true;
            while (running)
            {
                Console.WriteLine("\n1. Display Students");
                Console.WriteLine("2. Add Student");
                Console.WriteLine("3. Validate and Save Changes");
                Console.WriteLine("4. Refactor Enrollment Code");
                Console.WriteLine("5. Exit");
                Console.Write("\nChoose an option: ");
                
                string choice = Console.ReadLine();
                
                switch (choice)
                {
                    case "1":
                        DisplayStudents();
                        break;
                    case "2":
                        AddStudent();
                        break;
                    case "3":
                        ValidateAndSave();
                        break;
                    case "4":
                        RefactorEnrollment();
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }
            }
        }
        
        static void DisplayStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("\nNo students enrolled.");
                return;
            }
            
            Console.WriteLine("\n--- Students List ---");
            foreach (var student in students)
            {
                Console.WriteLine($"Name: {student.GetFullName()}, Email: {student.Email}, Age: {student.GetAge()}");
            }
        }
        
        static void AddStudent()
        {
            Console.Write("Enter first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter email: ");
            string email = Console.ReadLine();
            Console.Write("Enter birth year: ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("Enter birth month: ");
            int month = int.Parse(Console.ReadLine());
            Console.Write("Enter birth day: ");
            int day = int.Parse(Console.ReadLine());
            
            try
            {
                Student newStudent = new Student(firstName, lastName, email, new DateTime(year, month, day));
                if (ValidateStudent(newStudent))
                {
                    students.Add(newStudent);
                    Console.WriteLine("Student added successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        
        static bool ValidateStudent(Student student)
        {
            if (string.IsNullOrWhiteSpace(student.FirstName))
            {
                Console.WriteLine("First name cannot be empty!");
                return false;
            }
            
            if (string.IsNullOrWhiteSpace(student.LastName))
            {
                Console.WriteLine("Last name cannot be empty!");
                return false;
            }
            
            if (!student.Email.Contains("@"))
            {
                Console.WriteLine("Invalid email format!");
                return false;
            }
            
            return true;
        }
        
        static void ValidateAndSave()
        {
            Console.WriteLine("\nValidating all students...");
            bool allValid = true;
            
            foreach (var student in students)
            {
                if (!ValidateStudent(student))
                {
                    allValid = false;
                }
            }
            
            if (allValid)
            {
                Console.WriteLine("All students are valid. Changes saved successfully!");
            }
            else
            {
                Console.WriteLine("Some students have validation errors.");
            }
        }
        
        static void RefactorEnrollment()
        {
            Console.WriteLine("\nRefactoring enrollment code into separate methods...");
            ProcessEnrollment("Omar", "Hassan", "omar@school.com", 2012, 3, 10);
            ProcessEnrollment("Fatima", "Ibrahim", "fatima@school.com", 2011, 7, 25);
            Console.WriteLine("Enrollment refactored successfully!");
        }
        
        static void ProcessEnrollment(string firstName, string lastName, string email, int year, int month, int day)
        {
            try
            {
                Student student = new Student(firstName, lastName, email, new DateTime(year, month, day));
                if (ValidateStudent(student))
                {
                    students.Add(student);
                    Console.WriteLine($"Added: {student.GetFullName()}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing enrollment: {ex.Message}");
            }
        }
    }
    
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        private DateTime birthDate;
        
        public Student(string firstName, string lastName, string email, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            this.birthDate = birthDate;
        }
        
        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }
        
        public int GetAge()
        {
            int age = DateTime.Now.Year - birthDate.Year;
            if (DateTime.Now.DayOfYear < birthDate.DayOfYear)
                age--;
            return age;
        }
    }
}
