using System;
using System.Collections.Generic;

#nullable disable

namespace APlus.DataAccess.Models
{
    public partial class VwBioAppointment
    {
        public int Id { get; set; }
        public int TherapistId { get; set; }
        public int AppointmentId { get; set; }
        public string ShortName { get; set; }
        public string Therapist { get; set; }
    }
}