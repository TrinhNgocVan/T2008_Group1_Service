using System;
using System.Collections.Generic;

#nullable disable

namespace user_service.Models
{
    public partial class Role
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
    }
}
