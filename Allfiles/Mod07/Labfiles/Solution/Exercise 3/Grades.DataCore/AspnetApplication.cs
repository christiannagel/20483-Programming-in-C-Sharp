using System;
using System.Collections.Generic;

namespace Grades.Data
{
    public partial class AspnetApplication
    {
        public AspnetApplication()
        {
            AspnetMembership = new HashSet<AspnetMembership>();
            AspnetPaths = new HashSet<AspnetPath>();
            AspnetRoles = new HashSet<AspnetRoles>();
            AspnetUsers = new HashSet<AspnetUsers>();
        }

        public string ApplicationName { get; set; }
        public string LoweredApplicationName { get; set; }
        public Guid ApplicationId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<AspnetMembership> AspnetMembership { get; set; }
        public virtual ICollection<AspnetPath> AspnetPaths { get; set; }
        public virtual ICollection<AspnetRoles> AspnetRoles { get; set; }
        public virtual ICollection<AspnetUsers> AspnetUsers { get; set; }
    }
}
