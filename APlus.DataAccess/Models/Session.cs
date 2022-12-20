using System;
using System.Collections.Generic;

#nullable disable

namespace APlus.DataAccess.Models
{
    public partial class Session
    {
        public int Id { get; set; }
        public int SessionNumber { get; set; }
        public int ProgrammeId { get; set; }
        public string Name { get; set; }

        public virtual Programme Programme { get; set; }
    }
}