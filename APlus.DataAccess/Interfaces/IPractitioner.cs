using APlus.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APlus.DataAccess.Interfaces
{
    public interface IPractitioner
    {
        public Task<IEnumerable<Therapist>> GetPractitioners(bool listOnlyActive = true);
        public Task<IEnumerable<Therapist>> GetPractitionersByTreatmentType(int treatmentTypeId, bool listOnlyActive = true);
        public Task<IEnumerable<Therapist>> GetPractitionersByPractitionerTypeId(int practitionerTypeId, bool listOnlyActive = true);
        public Task<IEnumerable<Therapist>> GetPractitionersByLocation(int locationId, bool listOnlyActive = true);
        public Task<IEnumerable<Therapist>> GetPractitionersByLocationAndTreatmentType(int locationId, int treatmentTypeId, bool listOnlyActive = true);
        public Task<IEnumerable<Therapist>> GetPractitionersByLocationAndPractitionerTypeId(int locationId, int practitionerTypeId, bool listOnlyActive = true);
        public Task<Therapist> GetPractitioner(int practitionerId);
        public Task<Therapist> CreatePractitioner(Therapist practitioner);
        public Task<bool> UpdatePractitioner(Therapist practitioner, int pracitionerId);
        public Task<bool> UpdateActiveStatus(int practitionerId);

    }
}
