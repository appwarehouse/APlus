using APlus.DataAccess.Appointments;
using APlus.DataAccess.Models;
using APlus.Patient.Booking.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Itenso.TimePeriod;

namespace APlus.Patient.Booking.Services
{
    public class PractitionerAppointmentService : IPractitionerAppointmentService
    {
        private readonly IPractitionerAppointments _practitionerAppointments;

        public PractitionerAppointmentService(IPractitionerAppointments practitionerAppointments)
        {
            _practitionerAppointments = practitionerAppointments;
        }

        public async Task<List<TherapistAppointment>> CreatePractitionerAppointmentAsync(List<TherapistAppointment> newAppointments)
        {
            var newPractitionerAppointments = await _practitionerAppointments.CreateNewPractitionerAppointmentAsync(newAppointments);
            return newPractitionerAppointments;
        }

        public async Task<TherapistAppointment> CreatePractitionerAppointmentAsync(TherapistAppointment newAppointment)
        {
            var newPractitionerAppointment = await _practitionerAppointments.CreateNewPractitionerAppointmentAsync(newAppointment);
            return newPractitionerAppointment;
        }

        public async Task<List<TherapistAppointment>> GetAppointmentByLocationAndDateRangeAsync(int practitionerId, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TherapistAppointment>> GetAppointmentsByPractitionerIdAsync(int practitionerId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TherapistAppointment>> GetPractitionerAppointmentsByAppointmentIdAsync(int appointmentId)
        {
            throw new NotImplementedException();
        }

        public async Task<TherapistAppointment> GetPractitionerAppointmentsByPractitioinerAndAppointmentIdAsync(int practitioner, int appointmentId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdatePractitionerAppointmentAsync(TherapistAppointment appointment)
        {
            var updated = await _practitionerAppointments.UpdatePractitionerAppointmentAsync(appointment);
            return updated;
        }

        public Task<bool> UpdatePractitionerAppointmentAsync(int therapostAppointmentId, TherapistAppointment appointment)
        {
            throw new NotImplementedException();
        }
    }
}