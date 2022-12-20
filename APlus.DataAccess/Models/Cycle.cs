using System;
using System.Collections.Generic;

#nullable disable

namespace APlus.DataAccess.Models
{
    public partial class Cycle
    {
        public Cycle()
        {
            Appointments = new HashSet<Appointment>();
        }

        public long Id { get; set; }
        public int? PatientId { get; set; }
        public int? CycleNumber { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public bool? Active { get; set; }
        public DateTime? DischargeDate { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}