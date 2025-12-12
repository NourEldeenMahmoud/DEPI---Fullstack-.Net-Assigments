using System;
using System.Collections.Generic;

namespace TypeSafeApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Type-Safe Collections Application ===\n");
            
            List<Student> students = new List<Student>();
            Dictionary<string, int> gradeBook = new Dictionary<string, int>();
            
            students.Add(new Student("Ahmed", 20));
            students.Add(new Student("Sara", 19));
            students.Add(new Student("Omar", 21));
            
            gradeBook["Ahmed"] = 85;
            gradeBook["Sara"] = 90;
            gradeBook["Omar"] = 78;
            
            Console.WriteLine("--- Students List (Type-Safe) ---");
            foreach (var student in students)
            {
                Console.WriteLine($"Name: {student.Name}, Age: {student.Age}");
            }
            
            Console.WriteLine("\n--- Grade Book (Dictionary) ---");
            foreach (var entry in gradeBook)
            {
                Console.WriteLine($"Student: {entry.Key}, Grade: {entry.Value}");
            }
            
            Console.WriteLine("\n--- Searching Collections ---");
            var foundStudent = students.Find(s => s.Name == "Sara");
            if (foundStudent != null)
            {
                Console.WriteLine($"Found: {foundStudent.Name}, Age: {foundStudent.Age}");
            }
            
            if (gradeBook.ContainsKey("Ahmed"))
            {
                Console.WriteLine($"Ahmed's grade: {gradeBook["Ahmed"]}");
            }
        }
    }
    
    class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        
        public Student(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
