using System;
using System.Collections.Generic;

namespace Grades.DataCore
{
    public partial class Teacher
    {
        public Teacher()
        {
            Students = new HashSet<Student>();
        }

        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Class { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
