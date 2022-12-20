using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APlus.DataAccess.Models;

namespace APlus.Patient.Booking.Interfaces
{
    public interface IPatientService
    {
        public Task<DataAccess.Models.Patient> CreatePatientRecordAsync(DataAccess.Models.Patient patient);

        public Task<bool> UpdatePatientRecordAysnc(DataAccess.Models.Patient patient);

        public Task<Object> CreatePatientMedicalAidRecordAysnc(APlus.DataAccess.Models.Patient patient);

        public Task<bool> UpdatePatientMedicalAidRecordAysnc(APlus.DataAccess.Models.Patient patient);

        public Task<DataAccess.Models.Patient> FindPatientByIdNumber(string idNumber);
    }
}