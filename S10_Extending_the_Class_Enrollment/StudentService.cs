using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ClassEnrollmentApplication
{
    /// <summary>
    /// Service class for managing student operations
    /// Refactored from Program.cs to avoid code duplication
    /// </summary>
    public class StudentService
    {
        private List<Student> students;
        private const string DataFilePath = "students.txt";

        public StudentService()
        {
            students = new List<Student>();
            LoadStudentsFromFile();
        }

        /// <summary>
        /// Exercise 1: Refactoring the Enrollment Code
        /// Refactored methods to avoid duplication
        /// </summary>
        
        public List<Student> GetAllStudents()
        {
            return new List<Student>(students);
        }

        public Student FindStudentById(string studentId)
        {
            return students.FirstOrDefault(s => s.StudentId.Equals(studentId, StringComparison.OrdinalIgnoreCase));
        }

        public bool StudentExists(string studentId)
        {
            return students.Any(s => s.StudentId.Equals(studentId, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Exercise 2: Validating Student Information
        /// </summary>
        public void AddStudent(Student student)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student), "Student cannot be null.");

            if (StudentExists(student.StudentId))
                throw new InvalidOperationException($"Student with ID {student.StudentId} already exists.");

            students.Add(student);
            SaveStudentsToFile();
        }

        public void UpdateStudent(string studentId, string firstName, string lastName, DateTime dateOfBirth)
        {
            Student student = FindStudentById(studentId);
            if (student == null)
                throw new ArgumentException($"Student with ID {studentId} not found.");

            try
            {
                student.FirstName = firstName;
                student.LastName = lastName;
                student.DateOfBirth = dateOfBirth;
                SaveStudentsToFile();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error updating student: {ex.Message}", ex);
            }
        }

        public void DeleteStudent(string studentId)
        {
            Student student = FindStudentById(studentId);
            if (student == null)
                throw new ArgumentException($"Student with ID {studentId} not found.");

            students.Remove(student);
            SaveStudentsToFile();
        }

        /// <summary>
        /// Exercise 3: Saving Changes to the Class List
        /// </summary>
        private void SaveStudentsToFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(DataFilePath))
                {
                    foreach (var student in students)
                    {
                        writer.WriteLine($"{student.StudentId}|{student.FirstName}|{student.LastName}|{student.DateOfBirth:yyyy-MM-dd}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new IOException($"Error saving students to file: {ex.Message}", ex);
            }
        }

        private void LoadStudentsFromFile()
        {
            if (!File.Exists(DataFilePath))
                return;

            try
            {
                using (StreamReader reader = new StreamReader(DataFilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split('|');
                        if (parts.Length == 4)
                        {
                            try
                            {
                                var student = new Student(
                                    parts[1],
                                    parts[2],
                                    DateTime.Parse(parts[3]),
                                    parts[0]
                                );
                                students.Add(student);
                            }
                            catch
                            {
                                // Skip invalid lines
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Warning: Could not load students from file: {ex.Message}");
            }
        }
    }
}

