using System;
using System.Collections.Generic;

namespace Grades.Data
{
    public partial class Student
    {
        public Student()
        {
            Grades = new HashSet<Grade>();
        }

        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageName { get; set; }
        public Guid? TeacherUserId { get; set; }

        public virtual Teacher TeacherUser { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
