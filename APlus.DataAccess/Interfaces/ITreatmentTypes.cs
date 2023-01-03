using APlus.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APlus.DataAccess.Interfaces
{
    public interface ITreatmentTypes
    {
        public Task<IEnumerable<TreatmentType>> GetTreatmentTypes(bool listOnlyActive = true);
        public Task<TreatmentType> GetTreatmentType(int treatmentTypeId);
    }
}
