using System;
using System.Collections.Generic;

#nullable disable

namespace APlus.DataAccess.Models
{
    public partial class AuditTherapistAppointment
    {
        public int Id { get; set; }
        public int TherapistAppointmentId { get; set; }
        public int TherapistId { get; set; }
        public string TherapistName { get; set; }
        public int AppointmentId { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public int? Duration { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Action { get; set; }
    }
}