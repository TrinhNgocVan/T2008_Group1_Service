using System;
using System.Collections.Generic;

#nullable disable

namespace user_service.Models
{
    public partial class GroupUser
    {
        public long GroupId { get; set; }
        public long UserId { get; set; }

        public virtual AppGroup Group { get; set; }
        public virtual AppUser User { get; set; }
    }
}
