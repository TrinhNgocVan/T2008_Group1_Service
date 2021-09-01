using System;
using System.Collections.Generic;

#nullable disable

namespace user_service.Models
{
    public partial class AppGroup
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Enabled { get; set; }
        public int? SystemGroup { get; set; }
    }
}
