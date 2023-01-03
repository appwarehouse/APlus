using APlus.DataAccess.Database;
using APlus.DataAccess.Interfaces;
using APlus.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APlus.DataAccess.PractitionerTypes
{
    internal class PractitionerTypes : IPractitionerTypes
    {
        private readonly PatientContext _context;
        public PractitionerTypes(PatientContext context) {
            _context = context;

        }

        public Task<TherapistType> CreatePractitionerType(TherapistType practitionerType)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TherapistType>> GetPractitionerTypes(bool listOnlyActive)
        {
            var types = await _context.TherapistTypes.ToListAsync();

            if (!listOnlyActive) { return types; }
            return types.Where(q => q.IsActive == true).ToList();
        }

        public async Task<IEnumerable<TherapistType>> GetPractitionerTypesByTreatmentType(int treatmentTypeId, bool listOnlyActive)
        {
            var types = await _context.TherapistTypes.Where(q => q.TreatmentTypeId == treatmentTypeId).ToListAsync();

            if (!listOnlyActive) { return types; }
            return types.Where(q => q.IsActive == true).ToList();
        }

        public Task<bool> UpdatePractitionerType(TherapistType practitionerType, int therapistTypeId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePractitionerTypeStatus(int practitionerTypeId)
        {
            throw new NotImplementedException();
        }
    }
}
