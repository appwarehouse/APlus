using APlus.DataAccess.Database;
using APlus.DataAccess.Interfaces;
using APlus.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APlus.DataAccess.MedicalAid
{
    internal class MedicalAidProviders : IMedicalAidProvider
    {
        private readonly PatientContext _context;

        public MedicalAidProviders(PatientContext context)
        {
            _context= context;
        }
        public async Task<IEnumerable<MedicalAidProvider>> ListProviders(bool listOnlyActive = true)
        {
            var medicalAids = await _context.MedicalAidProviders.Where(x => x.Id > 0).OrderBy(x => x.Name.Trim()).ToListAsync();
            if (!listOnlyActive) return medicalAids;

            return medicalAids.Where(a => a.Active == true).ToList();
        }
    }
}
