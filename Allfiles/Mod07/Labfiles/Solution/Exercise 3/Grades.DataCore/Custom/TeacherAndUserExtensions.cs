﻿using System;
using System.Text.RegularExpressions;

namespace Grades.Data
{
    public enum Role { None, Teacher, Student };

    public partial class Teacher
    {
        public void RemoveFromClass(Student student)
        {
            // Verify that the student is actually assigned to the class for this teacher
            if (student.TeacherUserId == UserId)
            {
                // Reset the TeacherID property of the student
                student.TeacherUserId = null;
            }
            else
            {
                // If the student is not assigned to the class for this teacher, throw an ArgumentException
                throw new ArgumentException("Student", "Student is not assigned to this class");
            }
        }
    }

    public partial class User
    {
        public bool SetPassword(Role role, string pwd)
        {
            if (role == Role.Teacher)
            {
                // Use a regular expression to check that the password contains at least two numeric characters
                Match numericMatch = Regex.Match(pwd, @".*[0-9]+.*[0-9]+.*");

                // If the password provided as the parameter is at least 8 characters long and contains at least two numeric characters then save it and return true
                if (pwd.Length >= 8 && numericMatch.Success)
                {
                    UserPassword = pwd;
                    return true;
                }
            }
            else if (role == Role.Student)
            {
                // If the password provided as the parameter is at least 6 characters long then save it and return true
                if (pwd.Length >= 6)
                {
                    UserPassword = pwd;
                    return true;
                }
            }
            // If the password is either not complex enough (Teacher) or not long enough (Teacher or Student), then do not save it and return false
            return false;
        }

        public bool VerifyPassword(string pass)
            => (string.Compare(pass, UserPassword) == 0);
    }
}
