using System;
using System.Collections.Generic;

namespace Grades.DataCore
{
    public partial class Student
    {
        public Student()
        {
            Grades = new HashSet<Grade>();
            ParentStudent = new HashSet<ParentStudent>();
        }

        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageName { get; set; }
        public Guid? TeacherUserId { get; set; }

        public virtual Teacher TeacherUser { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
        public virtual ICollection<ParentStudent> ParentStudent { get; set; }
    }
}
