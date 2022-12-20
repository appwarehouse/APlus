using System;
using System.Collections.Generic;

#nullable disable

namespace APlus.DataAccess.Models
{
    public partial class SchedTherapistLunchBreakException
    {
        public int Id { get; set; }
        public int TherapistId { get; set; }
        public string ExceptionLunchTime { get; set; }
        public DateTime LunchBreak { get; set; }
        public int Duration { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastMobifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public bool Active { get; set; }

        public virtual Therapist Therapist { get; set; }
    }
}