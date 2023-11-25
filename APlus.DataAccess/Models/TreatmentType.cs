using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APlus.DataAccess.Models
{
    public class TreatmentType
    {
        public TreatmentType()
        {
            TreatmentTypeLocations = new HashSet<TreatmentTypeLocation>();
        }
        public int Id { get; set; }
        public string TreatmentTypeName { get; set; }
        public bool? IsActive { get; set; }
        public int TherapistTypeId { get; set; }
        public int AppointmentDuration { get; set; }

        [DefaultValue(true)]
        public Boolean IsPortalVisible { get; set; }
        public virtual TherapistType TherapistType { get; set; }
        public virtual ICollection<TreatmentTypeLocation> TreatmentTypeLocations { get;}
    }
}