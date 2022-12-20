using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APlus.DataAccess.Models
{
    internal class TreatmentType
    {
        public int Id { get; set; }
        public string TreatmentTypeName { get; set; }
        public bool? IsActive { get; set; }
        public int TherapistTypeId { get; set; }

        [DefaultValue(true)]
        public Boolean IsPortalVisible { get; set; }
    }
}