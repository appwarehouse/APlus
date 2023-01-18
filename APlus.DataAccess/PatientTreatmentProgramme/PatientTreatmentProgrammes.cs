using APlus.DataAccess.Database;
using APlus.DataAccess.Interfaces;
using APlus.DataAccess.Models;
using APlus.DataAccess.Patients;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APlus.DataAccess.PatientTreatmentProgramme
{
    internal class PatientTreatmentProgrammes : IPatientTreatmentProgrammes
    {
        private readonly PatientContext _context;
        public PatientTreatmentProgrammes(PatientContext context)
        {
            _context = context;
        }
        public async Task<PatientProgramme> EnrollPatientInPrograme(PatientProgramme programme, Patient patient)
        {
            return await EnrollPatientInPrograme(programme.Id, patient.Id);
        }

        public async Task<PatientProgramme> EnrollPatientInPrograme(PatientProgramme programme, int patientId)
        {
           return await EnrollPatientInPrograme(programme.Id, patientId);
        }

        public async Task<PatientProgramme> EnrollPatientInPrograme(int programmeId, int patientId)
        {
            var enrolled = new PatientProgramme { ProgrammeId = programmeId, PatientId = patientId };
            await _context.PatientProgrammes.AddAsync(enrolled);
            _context.SaveChanges();
            return enrolled;
        }

        public async Task<PatientProgramme> EnrollPatientInPrograme(int programmeId, Patient patient)
        {
            return await EnrollPatientInPrograme(programmeId, patient.Id);
        }

        public async Task<IEnumerable<PatientProgramme>> ListPatientEnrolledProgrammes(int patientId, bool listOnlyActive = true)
        {
            var list = await _context.PatientProgrammes.Include(p => p.Programme).Where(x=> x.PatientId == patientId).ToListAsync();

            if (!listOnlyActive)
                return list;

            return list.Where(x => x.Programme.Active == true);
        }
    }
}
