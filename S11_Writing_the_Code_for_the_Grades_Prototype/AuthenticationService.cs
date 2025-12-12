using System;
using System.Collections.Generic;

namespace GradesPrototype
{
    /// <summary>
    /// Service for user authentication
    /// </summary>
    public class AuthenticationService
    {
        private List<User> users;

        public AuthenticationService()
        {
            users = new List<User>();
            InitializeUsers();
        }

        public User? Authenticate(string username, string password)
        {
            User? user = users.FirstOrDefault(u => 
                u.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && 
                u.Authenticate(password));

            return user;
        }

        private void InitializeUsers()
        {
            users.Add(new User("teacher1", "pass123", UserRole.Teacher, "Ms. Sarah Johnson"));
            users.Add(new User("teacher2", "pass123", UserRole.Teacher, "Mr. David Smith"));
            users.Add(new User("student1", "pass123", UserRole.Student, "John Doe"));
            users.Add(new User("student2", "pass123", UserRole.Student, "Jane Smith"));
        }
    }
}

