using APlus.DataAccess.Database;
using APlus.DataAccess.Interfaces;
using APlus.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APlus.DataAccess.Patients
{
    internal class Patients : IPatients
    {
        private readonly PatientContext _context;

        public Patients(PatientContext context)
        {
            _context = context;
        }

        public async Task<Patient> CreatePatientAsync(Patient patientRecord)
        {
            await _context.Patients.AddAsync(patientRecord);
            await _context.SaveChangesAsync();
            return patientRecord;
        }

        public async Task<List<Patient>> FindPatientByEmailAddressAsync(string emailAddress)
        {
            var patients = await _context.Patients.Where(x => x.Email.ToLower() == emailAddress.ToLower().Trim()).ToListAsync();
            return patients;
        }

        public async Task<Patient> FindPatientByIdNumberAsync(string idNumber)
        {
            var patients = await _context.Patients.SingleOrDefaultAsync(x => x.Idnumber.ToLower() == idNumber.ToLower().Trim());
            return patients;
        }

        public async Task<List<Patient>> FindPatientByMobileNumberAsync(string mobileNumber)
        {
            var patients = await _context.Patients.Where(x => x.Mobile == mobileNumber).ToListAsync();
            return patients;
        }

        public async Task<List<Patient>> FindPatientByNameAsync(string name, string surname)
        {
            throw new NotImplementedException();
            //var patients = await _context.Patients.Where(x => x.Name.ToLower() like  emailAddress.ToLower().Trim()).ToListAsync();
            //return patients;
        }

        public async Task<Patient> FindPatientByPatientIdAsync(int patientId)
        {
            var patients = await _context.Patients.SingleOrDefaultAsync(x => x.Id == patientId);
            return patients;
        }

        public async Task<bool> UpdatePatientAsync(Patient patientRecord)
        {
            throw new NotImplementedException();
        }
    }
}