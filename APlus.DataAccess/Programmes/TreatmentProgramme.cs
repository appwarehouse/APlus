using APlus.DataAccess.Database;
using APlus.DataAccess.Interfaces;
using APlus.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APlus.DataAccess.Programmes
{
    internal class TreatmentProgramme : ITreatmentProgramme
    {

        private readonly PatientContext _context;
        public TreatmentProgramme(PatientContext context)
        {
            _context = context;
        }
        public async Task<Programme> GetTreatmentProgramme(int programmeId)
        {
          return await _context.Programmes.SingleOrDefaultAsync(x=> x.Id == programmeId);
        }

        public async Task<IEnumerable<Programme>> GetTreatmentProgrammes(bool listOnlyActive = true)
        {
            var list = await _context.Programmes.ToListAsync();

            if (! listOnlyActive) 
                return list;

         return list.Where(x => x.Active == true);
        }
    }
}
