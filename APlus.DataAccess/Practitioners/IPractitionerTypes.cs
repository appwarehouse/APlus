using APlus.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APlus.DataAccess.Practitioners
{
    public interface IPractitionerTypes
    {
        public Task<TherapistType> CreateNewPractitionerTypeAsync(TherapistType practitionerType);

        public Task<bool> UpdatePractitionerTypeAsync(TherapistType practitionerType);

        public Task<IEnumerable<TherapistType>> ListPractitionerType(bool listOnlyActive = true);
    }
}