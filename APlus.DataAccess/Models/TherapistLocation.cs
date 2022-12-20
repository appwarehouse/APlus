using System;
using System.Collections.Generic;

#nullable disable

namespace APlus.DataAccess.Models
{
    public partial class TherapistLocation
    {
        public int LocationId { get; set; }
        public int TherapistId { get; set; }

        public virtual Location Location { get; set; }
        public virtual Therapist Therapist { get; set; }
    }
}