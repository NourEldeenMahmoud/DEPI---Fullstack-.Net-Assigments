using System;
using System.Collections.Generic;

namespace GradesPrototype
{
    class Program
    {
        static List<User> users = new List<User>();
        static List<Grade> grades = new List<Grade>();
        static User currentUser = null;
        
        static void Main(string[] args)
        {
            InitializeData();
            
            Console.WriteLine("=== Grades Prototype Application ===\n");
            
            bool running = true;
            while (running)
            {
                if (currentUser == null)
                {
                    Login();
                }
                else
                {
                    ShowMenu();
                    string choice = Console.ReadLine();
                    
                    switch (choice)
                    {
                        case "1":
                            DisplayGrades();
                            break;
                        case "2":
                            AddGrade();
                            break;
                        case "3":
                            DisplayUserInfo();
                            break;
                        case "4":
                            Logout();
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
        }
        
        static void InitializeData()
        {
            users.Add(new User("teacher1", "password", UserType.Teacher));
            users.Add(new User("student1", "password", UserType.Student));
            users.Add(new User("student2", "password", UserType.Student));
            
            grades.Add(new Grade("student1", "Math", 85));
            grades.Add(new Grade("student1", "Science", 90));
            grades.Add(new Grade("student2", "Math", 78));
        }
        
        static void Login()
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            
            currentUser = users.Find(u => u.Username == username && u.Password == password);
            
            if (currentUser != null)
            {
                Console.WriteLine($"\nWelcome, {currentUser.Username} ({currentUser.Type})!");
            }
            else
            {
                Console.WriteLine("Invalid credentials!");
            }
        }
        
        static void ShowMenu()
        {
            Console.WriteLine("\n1. View Grades");
            Console.WriteLine("2. Add Grade (Teachers only)");
            Console.WriteLine("3. View User Info");
            Console.WriteLine("4. Logout");
            Console.WriteLine("5. Exit");
            Console.Write("\nChoose an option: ");
        }
        
        static void DisplayGrades()
        {
            Console.WriteLine("\n--- Grades ---");
            
            if (currentUser.Type == UserType.Teacher)
            {
                foreach (var grade in grades)
                {
                    Console.WriteLine($"Student: {grade.StudentUsername}, Subject: {grade.Subject}, Score: {grade.Score}");
                }
            }
            else
            {
                var studentGrades = grades.FindAll(g => g.StudentUsername == currentUser.Username);
                if (studentGrades.Count == 0)
                {
                    Console.WriteLine("No grades found.");
                }
                else
                {
                    foreach (var grade in studentGrades)
                    {
                        Console.WriteLine($"Subject: {grade.Subject}, Score: {grade.Score}");
                    }
                }
            }
        }
        
        static void AddGrade()
        {
            if (currentUser.Type != UserType.Teacher)
            {
                Console.WriteLine("Only teachers can add grades!");
                return;
            }
            
            Console.Write("Student username: ");
            string studentUsername = Console.ReadLine();
            Console.Write("Subject: ");
            string subject = Console.ReadLine();
            Console.Write("Score: ");
            int score = int.Parse(Console.ReadLine());
            
            grades.Add(new Grade(studentUsername, subject, score));
            Console.WriteLine("Grade added successfully!");
        }
        
        static void DisplayUserInfo()
        {
            Console.WriteLine($"\nUsername: {currentUser.Username}");
            Console.WriteLine($"Type: {currentUser.Type}");
        }
        
        static void Logout()
        {
            currentUser = null;
            Console.WriteLine("Logged out successfully!");
        }
    }
    
    enum UserType
    {
        Teacher,
        Student
    }
    
    struct User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public UserType Type { get; set; }
        
        public User(string username, string password, UserType type)
        {
            Username = username;
            Password = password;
            Type = type;
        }
    }
    
    struct Grade
    {
        public string StudentUsername { get; set; }
        public string Subject { get; set; }
        public int Score { get; set; }
        
        public Grade(string studentUsername, string subject, int score)
        {
            StudentUsername = studentUsername;
            Subject = subject;
            Score = score;
        }
    }
}
