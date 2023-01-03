using APlus.DataAccess.Database;
using APlus.DataAccess.Interfaces;
using APlus.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APlus.DataAccess.TreatmentTypes
{
    internal class TreatmentTypes : ITreatmentTypes
    {
        private readonly PatientContext _context;
        public TreatmentTypes(PatientContext context) {
            _context = context;
        }
        public async Task<TreatmentType> GetTreatmentType(int treatmentTypeId)
        {
           return await _context.TreatmentType.SingleOrDefaultAsync(q => q.Id == treatmentTypeId);
        }

        public async Task<IEnumerable<TreatmentType>> GetTreatmentTypes(bool listOnlyActive = true)
        {
            var types = await _context.TreatmentType.ToListAsync();

            if (!listOnlyActive) return types;

            return types.Where(p=> p.IsActive == true);

        }
    }
}
