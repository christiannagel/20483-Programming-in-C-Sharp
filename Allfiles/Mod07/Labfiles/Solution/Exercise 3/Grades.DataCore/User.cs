using System;
using System.Collections.Generic;

namespace Grades.DataCore
{
    public partial class User
    {
        public User()
        {
            UsersInRoles = new HashSet<UsersInRoles>();
        }

        public Guid ApplicationId { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public bool IsAnonymous { get; set; }
        public DateTime LastActivityDate { get; set; }
        public string UserPassword { get; set; }

        public virtual Applications Application { get; set; }
        public virtual Memberships Memberships { get; set; }
        public virtual Parent Parents { get; set; }
        public virtual Profiles Profiles { get; set; }
        public virtual Student Students { get; set; }
        public virtual Teacher Teachers { get; set; }
        public virtual ICollection<UsersInRoles> UsersInRoles { get; set; }
    }
}
