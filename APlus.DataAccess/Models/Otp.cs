using System;
using System.Collections.Generic;

#nullable disable

namespace APlus.DataAccess.Models
{
    public partial class Otp
    {
        public int Id { get; set; }
        public string MobileNumber { get; set; }
        public bool Sent { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime DateSent { get; set; }
        public int? Credits { get; set; }
        public string Status { get; set; }
        public long? EventId { get; set; }
        public string UserId { get; set; }
    }
}