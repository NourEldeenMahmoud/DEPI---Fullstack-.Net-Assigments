using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CloudDataAccess
{
    class Program
    {
        static List<Grade> localCache = new List<Grade>();
        
        static void Main(string[] args)
        {
            Console.WriteLine("=== Cloud Grade Data Access ===\n");
            
            SimulateCloudFetch();
            DisplayCachedData();
            SimulateCloudUpdate();
        }
        
        static void SimulateCloudFetch()
        {
            Console.WriteLine("Fetching data from cloud...");
            localCache.Add(new Grade("Ahmed", "Math", 85));
            localCache.Add(new Grade("Sara", "Science", 90));
            Console.WriteLine("Data fetched and cached locally.");
        }
        
        static void DisplayCachedData()
        {
            Console.WriteLine("\n--- Cached Grades ---");
            foreach (var grade in localCache)
            {
                Console.WriteLine($"Student: {grade.StudentName}, Subject: {grade.Subject}, Score: {grade.Score}");
            }
        }
        
        static void SimulateCloudUpdate()
        {
            Console.WriteLine("\nUpdating data in cloud...");
            localCache[0].Score = 88;
            Console.WriteLine("Data updated in cloud successfully.");
        }
    }
    
    class Grade
    {
        public string StudentName { get; set; }
        public string Subject { get; set; }
        public int Score { get; set; }
        
        public Grade(string studentName, string subject, int score)
        {
            StudentName = studentName;
            Subject = subject;
            Score = score;
        }
    }
}
