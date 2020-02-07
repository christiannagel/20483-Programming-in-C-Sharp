using System;
using System.Collections.Generic;
using System.Text;

namespace Grades.Data
{
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
}
