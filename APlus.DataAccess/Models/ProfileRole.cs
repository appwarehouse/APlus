using System;
using System.Collections.Generic;

#nullable disable

namespace APlus.DataAccess.Models
{
    public partial class ProfileRole
    {
        public int Profile { get; set; }
        public int Role { get; set; }

        public virtual Profile ProfileNavigation { get; set; }
    }
}