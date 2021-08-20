using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using user_service.Models;
namespace user_service.Dto
{
    public partial class AppUserDto
    {
        public long Id  { get; set; }
        public int? AccountExpired { get; set; }
        public int? AccountLocked { get; set; }
        public int? CredentialsExpired { get; set; }
        public int? AccountEnabled { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Version { get; set; }
        public int? UserLevel { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? PasswordChangedDate { get; set; }
        public long? ProfileId { get; set; }
        public string ProfileType { get; set; }

        public virtual Profile Profile { get; set; }
        public virtual IEnumerable<AppGroup> group { get; set; }
         public virtual IEnumerable<Role> role { get; set; }
    }
}
