using System;
using System.Collections.Generic;

namespace GradesPrototype
{
    /// <summary>
    /// Exercise 1: Adding Navigation Logic to the Grades Prototype Application
    /// Handles navigation between different views based on user role
    /// </summary>
    public class NavigationService
    {
        public enum ViewType
        {
            Login,
            TeacherDashboard,
            StudentDashboard,
            RecordGrades,
            ViewGrades
        }

        private ViewType currentView;
        private User currentUser;

        public NavigationService()
        {
            currentView = ViewType.Login;
        }

        public void NavigateTo(ViewType view)
        {
            currentView = view;
        }

        public ViewType GetCurrentView()
        {
            return currentView;
        }

        public void SetCurrentUser(User user)
        {
            currentUser = user;
        }

        public User GetCurrentUser()
        {
            return currentUser;
        }

        public void ShowView(ViewType view)
        {
            Console.Clear();
            Console.WriteLine("=".PadRight(60, '='));
            
            switch (view)
            {
                case ViewType.Login:
                    ShowLoginView();
                    break;
                case ViewType.TeacherDashboard:
                    ShowTeacherDashboard();
                    break;
                case ViewType.StudentDashboard:
                    ShowStudentDashboard();
                    break;
                case ViewType.RecordGrades:
                    ShowRecordGradesView();
                    break;
                case ViewType.ViewGrades:
                    ShowViewGradesView();
                    break;
            }
        }

        private void ShowLoginView()
        {
            Console.WriteLine("LOGIN VIEW");
            Console.WriteLine("=".PadRight(60, '='));
        }

        private void ShowTeacherDashboard()
        {
            Console.WriteLine($"TEACHER DASHBOARD - Welcome {currentUser.FullName}");
            Console.WriteLine("=".PadRight(60, '='));
        }

        private void ShowStudentDashboard()
        {
            Console.WriteLine($"STUDENT DASHBOARD - Welcome {currentUser.FullName}");
            Console.WriteLine("=".PadRight(60, '='));
        }

        private void ShowRecordGradesView()
        {
            Console.WriteLine("RECORD GRADES");
            Console.WriteLine("=".PadRight(60, '='));
        }

        private void ShowViewGradesView()
        {
            Console.WriteLine("VIEW GRADES");
            Console.WriteLine("=".PadRight(60, '='));
        }
    }
}

