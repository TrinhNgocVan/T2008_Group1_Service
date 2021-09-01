using System;
using System.Collections.Generic;

#nullable disable

namespace user_service.Models
{
    public partial class Debit
    {
        public int Id { get; set; }
        public long? ProfileId { get; set; }
        public int DebtType { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public int Approved { get; set; }
        public string ApprovedBy { get; set; }
        public string FileEvidence { get; set; }
        public int Latest { get; set; }
        public int IsPayed { get; set; }
        public string StartDay { get; set; }
        public string EndDay { get; set; }
        public string PayDate { get; set; }
       
        public virtual Profile Profile { get; set; }
    }
}
