using System;
using System.Collections.Generic;

#nullable disable

namespace APlus.DataAccess.Models
{
    public partial class SchedTherapistLunchBreak
    {
        public int Id { get; set; }
        public int TherapistId { get; set; }
        public string LunchTime { get; set; }
        public int DayNumber { get; set; }
        public int Duration { get; set; }
        public string DayName { get; set; }

        public virtual Therapist Therapist { get; set; }
    }
}