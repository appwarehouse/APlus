using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APlus.DataAccess.DTOs
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }
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
        public int AppointmentStatus { get; set; }
        public string AppointmentNotes { get; set; }
        public string AttendanceNotes { get; set; }
    }
}