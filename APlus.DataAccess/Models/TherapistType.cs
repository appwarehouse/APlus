using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace APlus.DataAccess.Models
{
    public partial class TherapistType
    {
        public TherapistType()
        {
            ProcedureCodes = new HashSet<ProcedureCode>();
            Therapists = new HashSet<Therapist>();
        }

        public int Id { get; set; }
        public string TherapistTypeName { get; set; }
        public bool? IsActive { get; set; }
        public int MaxConcurrantAppointments { get; set; }
        public string ShortName { get; set; }

        [DefaultValue(true)]
        public Boolean IsPortalVisible { get; set; }

        public virtual ICollection<ProcedureCode> ProcedureCodes { get; set; }
        public virtual ICollection<Therapist> Therapists { get; set; }
    }
}