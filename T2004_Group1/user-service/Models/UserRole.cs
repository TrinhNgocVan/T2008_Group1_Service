using System;
using System.Collections.Generic;

#nullable disable

namespace user_service.Models
{
    public partial class UserRole
    {
        public long RoleId { get; set; }
        public long UserId { get; set; }

        public virtual Role Role { get; set; }
        public virtual AppUser User { get; set; }
    }
}
