using System;
using System.Collections.Generic;

#nullable disable

namespace APlus.DataAccess.Models
{
    public partial class LocationProgramme
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public int ProgrammeId { get; set; }
        public DateTime DateAddedToProgramme { get; set; }

        public virtual Location Location { get; set; }
        public virtual Programme Programme { get; set; }
    }
}