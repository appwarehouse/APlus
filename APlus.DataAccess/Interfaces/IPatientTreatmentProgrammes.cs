using APlus.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APlus.DataAccess.Interfaces
{
    public interface IPatientTreatmentProgrammes
    {
        public Task<IEnumerable<PatientProgramme>> ListPatientEnrolledProgrammes(int patientId, bool listOnlyActive = true);
        public Task<PatientProgramme> EnrollPatientInPrograme(PatientProgramme programme, Patient patient);
        public Task<PatientProgramme> EnrollPatientInPrograme(PatientProgramme programme, int patientId);
        public Task<PatientProgramme> EnrollPatientInPrograme(int programmeId, int patientId);
        public Task<PatientProgramme> EnrollPatientInPrograme(int programmeId, Patient patient);
    }
}
