using System;
using System.Collections.Generic;

#nullable disable

namespace APlus.DataAccess.Models
{
    public partial class AppointmentStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? Active { get; set; }
        public string Description { get; set; }
        public bool Billable { get; set; }
        public bool Notes { get; set; }
        public bool? CanBook { get; set; }
        public bool IncludeInAnalytics { get; set; }
    }
}