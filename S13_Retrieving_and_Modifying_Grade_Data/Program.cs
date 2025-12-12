using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DatabaseOperations
{
    class Program
    {
        static string dataFile = "grades_data.txt";
        
        static void Main(string[] args)
        {
            Console.WriteLine("=== Grade Data Management ===\n");
            
            InitializeDataFile();
            
            Console.WriteLine("1. View All Grades");
            Console.WriteLine("2. Add Grade");
            Console.WriteLine("3. Update Grade");
            Console.WriteLine("4. Delete Grade");
            Console.Write("\nChoose an option: ");
            
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    ViewAllGrades();
                    break;
                case "2":
                    AddGrade();
                    break;
                case "3":
                    UpdateGrade();
                    break;
                case "4":
                    DeleteGrade();
                    break;
            }
        }
        
        static void InitializeDataFile()
        {
            if (!File.Exists(dataFile))
            {
                File.WriteAllLines(dataFile, new[] {
                    "Ahmed|Math|85",
                    "Sara|Science|90",
                    "Omar|English|78"
                });
            }
        }
        
        static void ViewAllGrades()
        {
            var lines = File.ReadAllLines(dataFile);
            Console.WriteLine("\n--- All Grades ---");
            foreach (var line in lines)
            {
                var parts = line.Split('|');
                Console.WriteLine($"Student: {parts[0]}, Subject: {parts[1]}, Grade: {parts[2]}");
            }
        }
        
        static void AddGrade()
        {
            Console.Write("Student name: ");
            string student = Console.ReadLine();
            Console.Write("Subject: ");
            string subject = Console.ReadLine();
            Console.Write("Grade: ");
            string grade = Console.ReadLine();
            
            File.AppendAllText(dataFile, $"\n{student}|{subject}|{grade}");
            Console.WriteLine("Grade added successfully!");
        }
        
        static void UpdateGrade()
        {
            var lines = File.ReadAllLines(dataFile).ToList();
            ViewAllGrades();
            
            Console.Write("\nEnter student name to update: ");
            string student = Console.ReadLine();
            Console.Write("Enter new grade: ");
            string newGrade = Console.ReadLine();
            
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].StartsWith(student + "|"))
                {
                    var parts = lines[i].Split('|');
                    lines[i] = $"{parts[0]}|{parts[1]}|{newGrade}";
                    break;
                }
            }
            
            File.WriteAllLines(dataFile, lines);
            Console.WriteLine("Grade updated successfully!");
        }
        
        static void DeleteGrade()
        {
            var lines = File.ReadAllLines(dataFile).ToList();
            ViewAllGrades();
            
            Console.Write("\nEnter student name to delete: ");
            string student = Console.ReadLine();
            
            lines.RemoveAll(l => l.StartsWith(student + "|"));
            File.WriteAllLines(dataFile, lines);
            Console.WriteLine("Grade deleted successfully!");
        }
    }
}
