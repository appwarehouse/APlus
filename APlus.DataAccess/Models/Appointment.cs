using APlus.DataAccess.Interfaces;
using System;
using System.Collections.Generic;

#nullable disable

namespace APlus.DataAccess.Models
{
    public partial class Appointment : IAppointmentModel
    {
        public Appointment()
        {
            TherapistAppointments = new HashSet<TherapistAppointment>();
        }

        public int Id { get; set; }
        public int LocationId { get; set; }
        public int PatientId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int? SessionNumber { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool Deleted { get; set; }
        public int? ProgrammeId { get; set; }
        public int AppointmentStatusId { get; set; }
        public string AppointmentNotes { get; set; }
        public string AttendanceNotes { get; set; }
        public long? CycleId { get; set; }

        public virtual Cycle Cycle { get; set; }
        public virtual Location Location { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual ICollection<TherapistAppointment> TherapistAppointments { get; set; }
    }
}