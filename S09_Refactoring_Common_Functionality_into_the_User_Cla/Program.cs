using System;

namespace InheritanceDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Inheritance and Class Hierarchy ===\n");
            
            User teacher = new Teacher("Ahmed", "ahmed@school.com");
            User student = new Student("Sara", "sara@school.com");
            
            Console.WriteLine("--- User Information ---");
            teacher.DisplayInfo();
            student.DisplayInfo();
            
            Console.WriteLine("\n--- Role-Specific Actions ---");
            if (teacher is Teacher t)
            {
                t.AssignGrade("Math", 85);
            }
            
            if (student is Student s)
            {
                s.ViewGrades();
            }
        }
    }
    
    class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        
        public User(string name, string email)
        {
            Name = name;
            Email = email;
        }
        
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"User: {Name} ({Email})");
        }
    }
    
    class Teacher : User
    {
        public Teacher(string name, string email) : base(name, email) { }
        
        public override void DisplayInfo()
        {
            Console.WriteLine($"Teacher: {Name} ({Email})");
        }
        
        public void AssignGrade(string subject, int score)
        {
            Console.WriteLine($"Assigned grade: {subject} - {score}");
        }
    }
    
    class Student : User
    {
        public Student(string name, string email) : base(name, email) { }
        
        public override void DisplayInfo()
        {
            Console.WriteLine($"Student: {Name} ({Email})");
        }
        
        public void ViewGrades()
        {
            Console.WriteLine("Viewing grades...");
        }
    }
}
