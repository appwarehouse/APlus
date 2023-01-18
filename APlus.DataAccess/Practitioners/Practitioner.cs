using APlus.DataAccess.Database;
using APlus.DataAccess.Interfaces;
using APlus.DataAccess.Models;
using APlus.DataAccess.PractitionerTypes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APlus.DataAccess.Practitioners
{
    internal class Practitioner : IPractitioner
    {
        private readonly PatientContext _context;

        public Practitioner(PatientContext context)
        {
            _context = context;
        }

        public Task<Therapist> CreatePractitioner(Therapist practitioner)
        {
            throw new NotImplementedException();
        }

        public Task<Therapist> GetPractitioner(int practitionerId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Therapist>> GetPractitioners(bool listOnlyActive=true)
        {
            var practitioners = await _context.Therapists.ToListAsync();
            if (!listOnlyActive) return practitioners;

            return practitioners.Where(q => q.IsActive == true).ToList();
        }

        public async Task<IEnumerable<Therapist>> GetPractitionersByLocation(int locationId, bool listOnlyActive = true)
        {
            var locations  = await _context.TherapistLocations.Where(q=> q.LocationId == locationId).ToListAsync();
            var practitioners = await _context.Therapists.ToListAsync();

            var filteredPractitioiners = practitioners.Where(p => locations.Any(l => l.TherapistId == p.Id)).ToList();

            if (!listOnlyActive) return filteredPractitioiners;

            return filteredPractitioiners.Where(q => q.IsActive == true).ToList();
        }

        public async Task<IEnumerable<Therapist>> GetPractitionersByLocationAndPractitionerTypeId(int locationId, int practitionerTypeId, bool listOnlyActive = true)
        {

            var locations = await _context.TherapistLocations.Where(q => q.LocationId == locationId).ToListAsync();
            var practitioners = await _context.Therapists.Where(p => p.TherapistType.Id == practitionerTypeId)
                                                            .Include(t => t.TherapistType)
                                                            .ToListAsync();

            var filteredPractitioiners = practitioners.Where(p => locations.Any(l => l.TherapistId == p.Id)).ToList();

            if (!listOnlyActive) return filteredPractitioiners;

            return filteredPractitioiners.Where(q => q.IsActive == true).ToList();
        }

        public async Task<IEnumerable<Therapist>> GetPractitionersByLocationAndTreatmentType(int locationId, int treatmentTypeId, bool listOnlyActive = true)
        {
            var practitioners = await (from a in _context.Therapists
                                 join t in _context.TherapistTypes on a.TherapistTypeId equals t.Id
                                 join r in _context.TreatmentType on t.Id equals r.TherapistTypeId
                                 join l in _context.TherapistLocations on a.Id equals l.TherapistId
                                 where r.Id == treatmentTypeId && l.LocationId == locationId select a).Include(t => t.TherapistType).ToListAsync();
                
            if (!listOnlyActive) return practitioners;

            return practitioners.Where(q => q.IsActive == true).ToList();
        }

        public async Task<IEnumerable<Therapist>> GetPractitionersByPractitionerTypeId(int practitionerTypeId, bool listOnlyActive = true)
        {
            var practitioners = await _context.Therapists.Where(p => p.TherapistType.Id == practitionerTypeId).ToListAsync();
            if (!listOnlyActive) return practitioners;

            return practitioners.Where(q => q.IsActive == true).ToList();
        }

        public async Task<IEnumerable<Therapist>> GetPractitionersByTreatmentType(int treatmentTypeId, bool listOnlyActive = true)
        {
            var practitioners = await (from a in _context.Therapists
                                       join t in _context.TherapistTypes on a.TherapistTypeId equals t.Id
                                       join r in _context.TreatmentType on t.Id equals r.TherapistTypeId
                                       where r.Id == treatmentTypeId 
                                       select a).Include(t => t.TherapistType).ToListAsync();

            if (!listOnlyActive) return practitioners;

            return practitioners.Where(q=> q.IsActive == true).ToList();
        }

        public Task<bool> UpdateActiveStatus(int practitionerId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePractitioner(Therapist practitioner, int pracitionerId)
        {
            throw new NotImplementedException();
        }
    }
}
