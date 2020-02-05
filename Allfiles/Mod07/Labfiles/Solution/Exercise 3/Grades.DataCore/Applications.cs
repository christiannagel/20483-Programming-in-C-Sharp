using System;
using System.Collections.Generic;

namespace Grades.DataCore
{
    public partial class Applications
    {
        public Applications()
        {
            Memberships = new HashSet<Memberships>();
            Roles = new HashSet<Role>();
            Users = new HashSet<User>();
        }

        public string ApplicationName { get; set; }
        public Guid ApplicationId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Memberships> Memberships { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
