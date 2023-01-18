using APlus.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APlus.DataAccess.Interfaces
{
    public interface IPatients
    {
        public Task<Patient> CreatePatientAsync(Patient patientRecord, int[] programmes = null);
        public Task<PatientProgramme> LinkPatientToProgrammeAsync(Patient patientRecord, Programme programme);

        public Task<bool> UpdatePatientAsync(Patient patientRecord);

        public Task<Patient> FindPatientByPatientIdAsync(int patientId);

        public Task<Patient> FindPatientByIdNumberAsync(string idNumber);

        public Task<List<Patient>> FindPatientByMobileNumberAsync(string mobileNumber);

        public Task<List<Patient>> FindPatientByEmailAddressAsync(string emailAddress);

        public Task<List<Patient>> FindPatientByNameAsync(string name, string surname);
    }
}