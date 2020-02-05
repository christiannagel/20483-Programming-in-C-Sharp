using System;
using System.Collections.Generic;

namespace Grades.DataCore
{
    public partial class AspnetPersonalizationAllUsers
    {
        public Guid PathId { get; set; }
        public byte[] PageSettings { get; set; }
        public DateTime LastUpdatedDate { get; set; }

        public virtual AspnetPaths Path { get; set; }
    }
}
