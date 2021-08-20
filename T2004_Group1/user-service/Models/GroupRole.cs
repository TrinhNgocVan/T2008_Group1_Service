using System;
using System.Collections.Generic;

#nullable disable

namespace user_service.Models
{
    public partial class GroupRole
    {
        public long GroupId { get; set; }
        public long RoleId { get; set; }

        public virtual AppGroup Group { get; set; }
        public virtual Role Role { get; set; }
    }
}
