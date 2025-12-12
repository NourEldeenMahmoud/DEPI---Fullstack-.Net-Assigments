using System;

namespace GradesPrototype
{
    /// <summary>
    /// Represents a grade for a student in a subject
    /// Exercise 2: Creating Data Types to Store Grade Information
    /// </summary>
    public struct Grade
    {
        public string StudentUsername { get; set; }
        public string Subject { get; set; }
        public double Score { get; set; }
        public DateTime DateRecorded { get; set; }

        public Grade(string studentUsername, string subject, double score, DateTime dateRecorded)
        {
            StudentUsername = studentUsername;
            Subject = subject;
            Score = score;
            DateRecorded = dateRecorded;
        }

        public string GetGradeLetter()
        {
            if (Score >= 90) return "A";
            if (Score >= 80) return "B";
            if (Score >= 70) return "C";
            if (Score >= 60) return "D";
            return "F";
        }

        public override string ToString()
        {
            return $"{Subject}: {Score:F1} ({GetGradeLetter()}) - {DateRecorded:MM/dd/yyyy}";
        }
    }
}

