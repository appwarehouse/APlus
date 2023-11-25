using APlus.DataAccess.PractitionerTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APlus.DataAccess.Models
{
    public class PractitionerTypeLocation
    {
        public PractitionerTypeLocation()
        {
        }
        public int Id { get; set; }
        public int LocationId { get; set; }
        public int TherapistTypeId { get; set; }
        public bool IsActive { get; set; }

        public virtual Location Location { get; set; }
        public virtual TherapistType TherapistType { get; set; }


    }
}
