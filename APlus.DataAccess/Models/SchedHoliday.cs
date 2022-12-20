using System;
using System.Collections.Generic;

#nullable disable

namespace APlus.DataAccess.Models
{
    public partial class SchedHoliday
    {
        public int Id { get; set; }
        public string Holiday { get; set; }
        public string Description { get; set; }
        public DateTime Day { get; set; }
        public bool IsRecurring { get; set; }
        public bool IsActive { get; set; }
    }
}