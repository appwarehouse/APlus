using System;
using System.Collections.Generic;

#nullable disable

namespace APlus.DataAccess.Models
{
    public partial class GlobalSetting
    {
        public int Id { get; set; }
        public string MailServer { get; set; }
        public string MailUserName { get; set; }
        public string MailPassword { get; set; }
        public int DefaultAdminAccountId { get; set; }
    }
}