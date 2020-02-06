using System;
using System.Collections.Generic;

namespace Grades.Data
{
    public partial class Parent
    {
        public Parent()
        {
            ParentStudent = new HashSet<ParentStudent>();
        }

        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<ParentStudent> ParentStudent { get; set; }
    }
}
