using System;
using System.Collections.Generic;

#nullable disable

namespace APlus.DataAccess.Models
{
    public partial class PatientProgramme
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int ProgrammeId { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual Programme Programme { get; set; }
    }
}