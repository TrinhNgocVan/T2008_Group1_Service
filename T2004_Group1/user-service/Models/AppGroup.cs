using System;
using System.Collections.Generic;

#nullable disable

namespace user_service.Models
{
    public partial class AppGroup
    {
        public AppGroup(long id, string name, string description, int? enabled, int? systemGroup)
        {
            Id = id;
            Name = name;
            Description = description;
            Enabled = enabled;
            SystemGroup = systemGroup;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Enabled { get; set; }
        public int? SystemGroup { get; set; }
    }
}
