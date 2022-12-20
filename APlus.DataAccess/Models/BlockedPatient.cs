using System;
using System.Collections.Generic;

#nullable disable

namespace APlus.DataAccess.Models
{
    public partial class BlockedPatient
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string BlockedById { get; set; }
        public string BlockedByName { get; set; }
        public string BlockedReason { get; set; }
        public string BlockedComment { get; set; }
        public bool? Active { get; set; }
        public DateTime DateBlocked { get; set; }
        public DateTime? DateUnblocked { get; set; }
        public string ReasonForUnblock { get; set; }
        public string UnblockedById { get; set; }
        public string UnblockedByName { get; set; }

        public virtual Patient Patient { get; set; }
    }
}