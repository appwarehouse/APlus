using System;
using System.Collections.Generic;

#nullable disable

namespace APlus.DataAccess.Models
{
    public partial class IncomingMessage
    {
        public int Id { get; set; }
        public long? ReplyId { get; set; }
        public long? EventId { get; set; }
        public string NumFrom { get; set; }
        public string Message { get; set; }
        public long? SentId { get; set; }
        public string SentMessage { get; set; }
        public int PatientId { get; set; }
        public DateTime? SentDate { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public bool MessageRead { get; set; }
    }
}