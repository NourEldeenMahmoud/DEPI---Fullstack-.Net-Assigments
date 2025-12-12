using System;
using System.Collections.Generic;

namespace ClassEnrollment
{
    class Program
    {
        static List<Student> students = new List<Student>();
        
        static void Main(string[] args)
        {
            Console.WriteLine("=== Class Enrollment Application ===\n");
            
            // Initialize with sample data
            students.Add(new Student("Ahmed", "Ali", new DateTime(2010, 5, 15)));
            students.Add(new Student("Sara", "Mohamed", new DateTime(2011, 8, 20)));
            
            bool running = true;
            while (running)
            {
                Console.WriteLine("\n1. Display Students");
                Console.WriteLine("2. Add Student");
                Console.WriteLine("3. Edit Student");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("5. Display Student Age");
                Console.WriteLine("6. Exit");
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
                        EditStudent();
                        break;
                    case "4":
                        DeleteStudent();
                        break;
                    case "5":
                        DisplayStudentAge();
                        break;
                    case "6":
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
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {students[i].FirstName} {students[i].LastName} (Age: {students[i].GetAge()})");
            }
        }
        
        static void AddStudent()
        {
            Console.Write("Enter first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter birth year: ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("Enter birth month: ");
            int month = int.Parse(Console.ReadLine());
            Console.Write("Enter birth day: ");
            int day = int.Parse(Console.ReadLine());
            
            students.Add(new Student(firstName, lastName, new DateTime(year, month, day)));
            Console.WriteLine("Student added successfully!");
        }
        
        static void EditStudent()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students to edit.");
                return;
            }
            
            DisplayStudents();
            Console.Write("\nEnter student number to edit: ");
            int index = int.Parse(Console.ReadLine()) - 1;
            
            if (index >= 0 && index < students.Count)
            {
                Console.Write("Enter new first name: ");
                students[index].FirstName = Console.ReadLine();
                Console.Write("Enter new last name: ");
                students[index].LastName = Console.ReadLine();
                Console.WriteLine("Student updated successfully!");
            }
            else
            {
                Console.WriteLine("Invalid student number!");
            }
        }
        
        static void DeleteStudent()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students to delete.");
                return;
            }
            
            DisplayStudents();
            Console.Write("\nEnter student number to delete: ");
            int index = int.Parse(Console.ReadLine()) - 1;
            
            if (index >= 0 && index < students.Count)
            {
                students.RemoveAt(index);
                Console.WriteLine("Student deleted successfully!");
            }
            else
            {
                Console.WriteLine("Invalid student number!");
            }
        }
        
        static void DisplayStudentAge()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students enrolled.");
                return;
            }
            
            DisplayStudents();
            Console.Write("\nEnter student number: ");
            int index = int.Parse(Console.ReadLine()) - 1;
            
            if (index >= 0 && index < students.Count)
            {
                int age = students[index].GetAge();
                Console.WriteLine($"\n{students[index].FirstName} {students[index].LastName} is {age} years old.");
            }
            else
            {
                Console.WriteLine("Invalid student number!");
            }
        }
    }
    
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        private DateTime birthDate;
        
        public Student(string firstName, string lastName, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            this.birthDate = birthDate;
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
