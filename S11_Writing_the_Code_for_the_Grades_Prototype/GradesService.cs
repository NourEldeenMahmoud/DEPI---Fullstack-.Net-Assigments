using System;
using System.Collections.Generic;
using System.Linq;

namespace GradesPrototype
{
    /// <summary>
    /// Service for managing grades
    /// </summary>
    public class GradesService
    {
        private List<Grade> grades;

        public GradesService()
        {
            grades = new List<Grade>();
            InitializeSampleGrades();
        }

        public void AddGrade(Grade grade)
        {
            grades.Add(grade);
        }

        public List<Grade> GetGradesForStudent(string studentUsername)
        {
            return grades.Where(g => g.StudentUsername == studentUsername).ToList();
        }

        public List<Grade> GetAllGrades()
        {
            return new List<Grade>(grades);
        }

        public List<string> GetStudents()
        {
            return grades.Select(g => g.StudentUsername).Distinct().ToList();
        }

        private void InitializeSampleGrades()
        {
            grades.Add(new Grade("student1", "Mathematics", 85.5, DateTime.Now.AddDays(-10)));
            grades.Add(new Grade("student1", "Science", 92.0, DateTime.Now.AddDays(-8)));
            grades.Add(new Grade("student1", "English", 78.5, DateTime.Now.AddDays(-5)));
            grades.Add(new Grade("student2", "Mathematics", 90.0, DateTime.Now.AddDays(-9)));
            grades.Add(new Grade("student2", "Science", 88.5, DateTime.Now.AddDays(-7)));
        }
    }
}

