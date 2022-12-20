using APlus.DataAccess.Database;
using APlus.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APlus.DataAccess.Practitioners
{
    internal class PractitionerTypes : IPractitionerTypes
    {
        private readonly PatientContext _context;

        public PractitionerTypes(PatientContext context)
        {
            _context = context;
        }

        public Task<TherapistType> CreateNewPractitionerTypeAsync(TherapistType practitionerType)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TherapistType>> ListPractitionerType(bool listOnlyActive = true)
        {
            var allPractitionerTypes = await _context.TherapistTypes.ToListAsync();
            if (!listOnlyActive)
                return allPractitionerTypes;

            return allPractitionerTypes.Where(x => x.IsActive == true).ToList();
        }

        public Task<bool> UpdatePractitionerTypeAsync(TherapistType practitionerType)
        {
            throw new NotImplementedException();
        }
    }
}