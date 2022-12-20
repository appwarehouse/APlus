using System;
using System.Collections.Generic;

#nullable disable

namespace APlus.DataAccess.Models
{
    public partial class Template
    {
        public int Id { get; set; }
        public string TemplateName { get; set; }
        public string TemplateContent { get; set; }
    }
}