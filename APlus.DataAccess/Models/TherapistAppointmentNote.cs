using System;
using System.Collections.Generic;

#nullable disable

namespace APlus.DataAccess.Models
{
    public partial class TherapistAppointmentNote
    {
        public int Id { get; set; }
        public string Note { get; set; }
        public int TherapistAppointmentId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int CreatedBy { get; set; }

        public virtual TherapistAppointment TherapistAppointment { get; set; }
    }
}