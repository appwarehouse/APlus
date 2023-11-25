using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APlus.DataAccess.Models
{
    public class TreatmentTypeLocation
    {
        public int Id { get; set; }
        public int TreatmentTypeId { get; set; }
        public int LocationId { get; set; }
        public bool isActive { get; set; }

        public virtual Location Location { get; set; }
        public virtual TreatmentType TreatmentType { get; set; }

    }
}
