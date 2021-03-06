using System;
using System.Collections.Generic;

#nullable disable

namespace user_service.Models
{
    public partial class Profile
    {
        public Profile()
        {
            AppUsers = new HashSet<AppUser>();
            Debits = new HashSet<Debit>();
        }

        public long Id { get; set; }
        public string Fullname { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string OrgIdentityCode { get; set; }
        public string Salary { get; set; }
        public string InsuranceSalary { get; set; }
        public long? LongTermAllowance { get; set; }

        public virtual Organization OrgIdentityCodeNavigation { get; set; }
        public virtual ICollection<AppUser> AppUsers { get; set; }
        public virtual ICollection<Debit> Debits { get; set; }
    }
}
