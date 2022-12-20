using System;
using System.Collections.Generic;

#nullable disable

namespace APlus.DataAccess.Models
{
    public partial class TherapistAppointmentProcedureCode
    {
        public int Id { get; set; }
        public int ProcedureCodeId { get; set; }
        public int TherapistAppointmentId { get; set; }

        public virtual ProcedureCode ProcedureCode { get; set; }
        public virtual TherapistAppointment TherapistAppointment { get; set; }
    }
}