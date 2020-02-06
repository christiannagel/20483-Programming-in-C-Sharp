using System;
using System.Collections.Generic;

namespace Grades.Data
{
    public partial class Role
    {
        public Role()
        {
            UsersInRoles = new HashSet<UserInRole>();
        }

        public Guid ApplicationId { get; set; }
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }

        public virtual Application Application { get; set; }
        public virtual ICollection<UserInRole> UsersInRoles { get; set; }
    }
}
