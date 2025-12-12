using System;
using System.IO;
using System.Text;

namespace GradesReport
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Grades Report Generator ===\n");
            
            StringBuilder report = new StringBuilder();
            report.AppendLine("=== GRADES REPORT ===");
            report.AppendLine($"Generated: {DateTime.Now}");
            report.AppendLine();
            
            report.AppendLine("Student: Ahmed Ali");
            report.AppendLine("  Math: 85");
            report.AppendLine("  Science: 90");
            report.AppendLine("  English: 88");
            report.AppendLine();
            
            report.AppendLine("Student: Sara Mohamed");
            report.AppendLine("  Math: 92");
            report.AppendLine("  Science: 87");
            report.AppendLine("  English: 95");
            report.AppendLine();
            
            report.AppendLine("=== END OF REPORT ===");
            
            Console.WriteLine(report.ToString());
            
            string fileName = "grades_report.txt";
            File.WriteAllText(fileName, report.ToString());
            Console.WriteLine($"\nReport saved to {fileName}");
        }
    }
}
