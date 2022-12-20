using System;
using System.Collections.Generic;

#nullable disable

namespace APlus.DataAccess.Models
{
    public partial class OutgoingMessage
    {
        public int Id { get; set; }
        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Message { get; set; }
        public bool Sent { get; set; }
        public string ErrorMessage { get; set; }
        public string SentByUserId { get; set; }
        public DateTime DateSent { get; set; }
        public int? Credits { get; set; }
        public string Status { get; set; }
        public long? EventId { get; set; }
        public int? Patientid { get; set; }

        public virtual Patient Patient { get; set; }
    }
}