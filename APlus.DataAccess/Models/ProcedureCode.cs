using System;
using System.Collections.Generic;

#nullable disable

namespace APlus.DataAccess.Models
{
    public partial class ProcedureCode
    {
        public ProcedureCode()
        {
            TherapistAppointmentProcedureCodes = new HashSet<TherapistAppointmentProcedureCode>();
        }

        public int Id { get; set; }
        public string ProcedureCode1 { get; set; }
        public string Description { get; set; }
        public int TherapistType { get; set; }

        public virtual TherapistType TherapistTypeNavigation { get; set; }
        public virtual ICollection<TherapistAppointmentProcedureCode> TherapistAppointmentProcedureCodes { get; set; }
    }
}