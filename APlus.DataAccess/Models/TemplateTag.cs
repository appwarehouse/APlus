using System;
using System.Collections.Generic;

#nullable disable

namespace APlus.DataAccess.Models
{
    public partial class TemplateTag
    {
        public string Tag { get; set; }
        public string IdField { get; set; }
        public string TableName { get; set; }
        public string QueryStatement { get; set; }
    }
}