using System;

namespace GradesPrototype
{
    /// <summary>
    /// Represents a user in the Grades Prototype Application
    /// Exercise 2: Creating Data Types to Store User Information
    /// </summary>
    public struct User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
        public string FullName { get; set; }

        public User(string username, string password, UserRole role, string fullName)
        {
            Username = username;
            Password = password;
            Role = role;
            FullName = fullName;
        }

        public bool Authenticate(string password)
        {
            return Password == password;
        }
    }

    public enum UserRole
    {
        Teacher,
        Student
    }
}

