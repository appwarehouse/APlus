using APlus.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APlus.DataAccess.Interfaces
{
    public interface IPractitionerTypes
    {
        public Task<IEnumerable<TherapistType>> GetPractitionerTypes(bool listOnlyActive = true);
        public Task<IEnumerable<PractitionerTypeLocation>> GetPractitionerTypesAndLocations(bool listOnlyActive = true);
        public Task<IEnumerable<TherapistType>> GetPractitionerTypesByTreatmentType(int treatmentTypeId, bool listOnlyActive = true);
        public Task<TherapistType> CreatePractitionerType(TherapistType practitionerType);
        public Task<bool> UpdatePractitionerType(TherapistType practitionerType, int therapistTypeId);
        public Task<bool> UpdatePractitionerTypeStatus(int practitionerTypeId);

    }
}
