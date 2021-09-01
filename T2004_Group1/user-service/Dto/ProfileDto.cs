using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using user_service.Models;
namespace user_service.Dto
{
    public class ProfileDto
    {
        public ProfileDto()
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
        public string FullSalary { get; set; }
        public string InsuranceSalary { get; set; }
        public DateTime? PayDate { get; set; }
        public long? LongTermAllowance { get; set; }
        public string realSalary  { get; set; }
        public int month { get; set; }

        public virtual Organization OrgIdentityCodeNavigation { get; set; }
        public virtual ICollection<AppUser> AppUsers { get; set; }
        public virtual ICollection<Debit> Debits { get; set; }
    }
}
