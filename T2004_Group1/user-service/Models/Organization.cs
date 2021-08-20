using System;
using System.Collections.Generic;

#nullable disable

namespace user_service.Models
{
    public partial class Organization
    {
        public Organization()
        {
            Profiles = new HashSet<Profile>();
        }

        public long Id { get; set; }
        public string Code { get; set; }
        public string IdentityCode { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Profile> Profiles { get; set; }
    }
}
