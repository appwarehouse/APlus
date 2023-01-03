using APlus.DataAccess.Interfaces;
using APlus.DataAccess.Models;
using APlus.DataAccess.Practitioners;
using APlus.Patient.Booking.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APlus.Patient.Booking.Services
{
    public class PractitionerTypeService : IPractitionerTypeService
    {
        private readonly IPractitionerTypes _practitionerTypes;

        public PractitionerTypeService(IPractitionerTypes practitionerTypes)
        {
            _practitionerTypes = practitionerTypes;
        }
        public async Task<List<TherapistType>> GetPractitionerTypes()
        {
            var patientPortalPractitionerTypes = await _practitionerTypes.GetPractitionerTypes();
            return patientPortalPractitionerTypes.Where(x => x.IsPortalVisible = true).ToList();
        }
    }
}
