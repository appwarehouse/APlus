using System;
using System.Collections.Generic;

#nullable disable

namespace APlus.DataAccess.Models
{
    public partial class VwBlockedPatient
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BlockedById { get; set; }
        public string BlockedByName { get; set; }
        public string BlockedComment { get; set; }
        public bool Active { get; set; }
        public DateTime DateBlocked { get; set; }
        public string BlockedReason { get; set; }
    }
}