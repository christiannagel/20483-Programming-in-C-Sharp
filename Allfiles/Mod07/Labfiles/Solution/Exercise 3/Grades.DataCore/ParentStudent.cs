using System;
using System.Collections.Generic;

namespace Grades.Data
{
    public partial class ParentStudent
    {
        public Guid ParentsUserId { get; set; }
        public Guid StudentsUserId { get; set; }

        public virtual Parent ParentsUser { get; set; }
        public virtual Student StudentsUser { get; set; }
    }
}
