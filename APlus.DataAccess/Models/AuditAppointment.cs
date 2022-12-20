using System;
using System.Collections.Generic;

#nullable disable

namespace APlus.DataAccess.Models
{
    public partial class AuditAppointment
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public int LocationId { get; set; }
        public string Location { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int? SessionNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedById { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool Deleted { get; set; }
        public int? ProgrammeId { get; set; }
        public int AppointmentStatusId { get; set; }
        public string AppointmentNotes { get; set; }
        public string AttendanceNotes { get; set; }
        public long? CycleId { get; set; }
        public string Action { get; set; }
    }
}