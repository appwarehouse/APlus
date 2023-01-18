using APlus.DataAccess.Interfaces;
using APlus.DataAccess.Models;
using APlus.Patient.Booking.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APlus.Patient.Booking.Services
{
    public class TreatmentTypeService:ITreatmentTypesService
    {
        private readonly ITreatmentTypes _treatmentTypes;
        public TreatmentTypeService(ITreatmentTypes treatmentTypes) 
        {
            _treatmentTypes = treatmentTypes;
        }

        public async Task<List<TreatmentType>> GetTreatmentTypes()
        {
           var list =  await _treatmentTypes.GetTreatmentTypes();
            return list.ToList().Where(x => x.IsPortalVisible == true).ToList();
        }
    }
}
