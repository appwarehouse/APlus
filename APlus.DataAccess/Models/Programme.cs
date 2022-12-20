using System;
using System.Collections.Generic;

#nullable disable

namespace APlus.DataAccess.Models
{
    public partial class Programme
    {
        public Programme()
        {
            LocationProgrammes = new HashSet<LocationProgramme>();
            PatientProgrammes = new HashSet<PatientProgramme>();
        }

        public int Id { get; set; }
        public string ProgrammeName { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<LocationProgramme> LocationProgrammes { get; set; }
        public virtual ICollection<PatientProgramme> PatientProgrammes { get; set; }
    }
}