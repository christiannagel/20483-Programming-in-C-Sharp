using System;
using System.Collections.Generic;

namespace Grades.Data
{
    public partial class AspnetPersonalizationAllUsers
    {
        public Guid PathId { get; set; }
        public byte[] PageSettings { get; set; }
        public DateTime LastUpdatedDate { get; set; }

        public virtual AspnetPath Path { get; set; }
    }
}
