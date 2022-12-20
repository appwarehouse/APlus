using System;
using System.Collections.Generic;

#nullable disable

namespace APlus.DataAccess.Models
{
    public partial class Profile
    {
        public Profile()
        {
            ProfileRoles = new HashSet<ProfileRole>();
        }

        public int Id { get; set; }
        public string Profile1 { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<ProfileRole> ProfileRoles { get; set; }
    }
}