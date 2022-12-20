using APlus.DataAccess.Interfaces;
using System;
using System.Collections.Generic;

#nullable disable

namespace APlus.DataAccess.Models
{
    public partial class TherapistAppointment : IAppointmentModel

    {
        public TherapistAppointment()
        {
            TherapistAppointmentNotes = new HashSet<TherapistAppointmentNote>();
            TherapistAppointmentProcedureCodes = new HashSet<TherapistAppointmentProcedureCode>();
        }

        public int Id { get; set; }
        public int TherapistId { get; set; }
        public int AppointmentId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int? Duration { get; set; }

        public virtual Appointment Appointment { get; set; }
        public virtual Therapist Therapist { get; set; }
        public virtual ICollection<TherapistAppointmentNote> TherapistAppointmentNotes { get; set; }
        public virtual ICollection<TherapistAppointmentProcedureCode> TherapistAppointmentProcedureCodes { get; set; }
    }
}