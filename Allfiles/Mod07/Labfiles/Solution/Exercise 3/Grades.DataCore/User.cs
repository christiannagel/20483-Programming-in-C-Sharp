using System;
using System.Collections.Generic;

namespace Grades.Data
{
    public partial class User
    {
        public Guid ApplicationId { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public bool IsAnonymous { get; set; }
        public DateTime LastActivityDate { get; set; }
        public string UserPassword { get; set; }
        public virtual Student Students { get; set; }
        public virtual Teacher Teachers { get; set; }
    }
}
