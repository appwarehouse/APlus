using System;
using System.Collections.Generic;

#nullable disable

namespace APlus.DataAccess.Models
{
    public partial class TherapistTypeProgramme
    {
        public int Id { get; set; }
        public int TherapistTypeId { get; set; }
        public int ProgrammeId { get; set; }
    }
}