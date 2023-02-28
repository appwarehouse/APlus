using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APlus.DataAccess.Models;
using APlus.DataAccess.Appointments;
using APlus.Patient.Booking.Interfaces;
using Itenso.TimePeriod;

namespace APlus.Patient.Booking.Services
{
    public class PatientAppointmentService : IAppointmentService
    {
        private IAppointments _appointments;

        public PatientAppointmentService(IAppointments appointments)
        {
            _appointments = appointments;
        }

        public async Task<bool> CancelAppointmentAsync(int appointmentId)
        {
            var cancelled =await _appointments.CancelAppointmentAsync(appointmentId);
            return cancelled;
        }

        public Task<Appointment> CreateAppointmentAsync(Appointment newAppointment)
        {
            var appointment = _appointments.CreateNewAppointmentAsync(newAppointment);
            return appointment;
        }

        public Task<List<Appointment>> GetAppointmentByLocationAndDateRangeAsync(int id, DateTime startDate, DateTime ednDate)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Appointment>> GetAppointmentsByPatientAsync(int id)
        {
            var patientAppointments = await _appointments.ListAppointmentsByPatientId(id);
            return patientAppointments.ToList();
        }

        public Task<List<Appointment>> GetAppointmentsByPractitionerAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Appointment>> GetAppointmentsByPractitionerForLocationAsync(int id, int locationId)
        {
            throw new NotImplementedException();
        }

        public async Task<Appointment> GetPatientAppointment(int patientId, int id)
        {
            var appointment = await _appointments.GetAppointmentAsync(id);
            if (appointment.PatientId == patientId)
                return appointment;
            return null;
        }
        public async Task<Appointment> GetPatientAppointment(int id)
        {
            var appointment = await _appointments.GetAppointmentAsync(id);
            return appointment;
        }

        public Task<bool> UpdateAppointmentAsync(int appointmentId, Appointment appointment)
        {
            throw new NotImplementedException();
        }
    }
}