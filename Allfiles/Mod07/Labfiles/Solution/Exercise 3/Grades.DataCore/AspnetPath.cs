using System;
using System.Collections.Generic;

namespace Grades.Data
{
    public partial class AspnetPath
    {
        public AspnetPath()
        {
            AspnetPersonalizationPerUser = new HashSet<AspnetPersonalizationPerUser>();
        }

        public Guid ApplicationId { get; set; }
        public Guid PathId { get; set; }
        public string Path { get; set; }
        public string LoweredPath { get; set; }

        public virtual AspnetApplication Application { get; set; }
        public virtual AspnetPersonalizationAllUsers AspnetPersonalizationAllUsers { get; set; }
        public virtual ICollection<AspnetPersonalizationPerUser> AspnetPersonalizationPerUser { get; set; }
    }
}
