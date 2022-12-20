using System;
using System.Collections.Generic;

#nullable disable

namespace APlus.DataAccess.Models
{
    public partial class SchedTherapistAvailabilitySchedule
    {
        public int Id { get; set; }
        public int TherapistId { get; set; }
        public int LocationId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastMobifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public bool Active { get; set; }

        public virtual AspNetUser CreatedByNavigation { get; set; }
        public virtual Location Location { get; set; }
        public virtual Therapist Therapist { get; set; }
    }
}