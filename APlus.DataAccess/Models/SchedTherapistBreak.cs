using System;
using System.Collections.Generic;

#nullable disable

namespace APlus.DataAccess.Models
{
    public partial class SchedTherapistBreak
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime BreakStart { get; set; }
        public DateTime BreakEnd { get; set; }
        public bool AllDay { get; set; }
        public int TherapistId { get; set; }
        public int? ExternalId { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }

        public virtual AspNetUser CreatedByNavigation { get; set; }
        public virtual Therapist Therapist { get; set; }
    }
}