using System;
using System.Collections.Generic;

#nullable disable

namespace APlus.DataAccess.Models
{
    public partial class BranchTarget
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public int ProgrammeId { get; set; }
        public int LocationId { get; set; }
        public bool? MedicalAid { get; set; }
        public int NewPatients { get; set; }
        public int Interim { get; set; }
        public int Outcomes { get; set; }
        public int Target { get; set; }
    }
}