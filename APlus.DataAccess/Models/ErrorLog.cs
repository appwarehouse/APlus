using System;
using System.Collections.Generic;

#nullable disable

namespace APlus.DataAccess.Models
{
    public partial class ErrorLog
    {
        public int Id { get; set; }
        public string Error { get; set; }
        public string StackTrace { get; set; }
        public DateTime DateCreated { get; set; }
        public string InnerException { get; set; }
        public string InnerExceptionMessage { get; set; }
        public string UserId { get; set; }
    }
}