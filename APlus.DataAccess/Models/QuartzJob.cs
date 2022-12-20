using System;
using System.Collections.Generic;

#nullable disable

namespace APlus.DataAccess.Models
{
    public partial class QuartzJob
    {
        public int Id { get; set; }
        public string JobName { get; set; }
        public DateTime RunStart { get; set; }
        public DateTime? RunEnd { get; set; }
        public string Duration { get; set; }
        public string Status { get; set; }
        public string ErrorDetails { get; set; }
    }
}