﻿using System;
using System.Collections.Generic;

namespace Grades.DataCore
{
    public partial class UsersInRoles
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
