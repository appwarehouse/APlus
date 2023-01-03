using APlus.DataAccess.Interfaces;
using APlus.Patient.Booking.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APlus.Patient.Booking.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatients _patient;

        public PatientService(IPatients patient)
        {
            _patient = patient;
        }

        public Task<object> CreatePatientMedicalAidRecordAysnc(DataAccess.Models.Patient patient)
        {
            throw new NotImplementedException();
        }

        public Task<DataAccess.Models.Patient> CreatePatientRecordAsync(DataAccess.Models.Patient patient)
        {
            var newPatient = _patient.CreatePatientAsync(patient);
            return newPatient;
        }

        public async Task<DataAccess.Models.Patient> FindPatientByIdNumber(string idNumber)
        {
            var patient = await _patient.FindPatientByIdNumberAsync(idNumber);
            return patient;
        }

        public Task<bool> UpdatePatientMedicalAidRecordAysnc(DataAccess.Models.Patient patient)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePatientRecordAysnc(DataAccess.Models.Patient patient)
        {
            throw new NotImplementedException();
        }
    }
}