using System;
using System.Collections.Generic;

namespace Grades.Data
{
    public partial class Subject
    {
        public Subject()
        {
            Grades = new HashSet<Grade>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }
    }
}
