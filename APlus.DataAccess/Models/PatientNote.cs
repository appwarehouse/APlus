using System;
using System.Collections.Generic;

#nullable disable

namespace APlus.DataAccess.Models
{
    public partial class PatientNote
    {
        public int Id { get; set; }
        public string NoteText { get; set; }
        public int PatientId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Deleted { get; set; }

        public virtual AspNetUser CreatedByNavigation { get; set; }
        public virtual Patient Patient { get; set; }
    }
}