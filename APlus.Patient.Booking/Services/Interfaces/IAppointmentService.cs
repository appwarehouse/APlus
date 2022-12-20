using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APlus.DataAccess.Models;

namespace APlus.Patient.Booking.Interfaces
{
    public interface IAppointmentService
    {
        public Task<Appointment> CreateAppointmentAsync(Appointment newAppointment);

        public Task<bool> CancelAppointmentAsync(int appointmentId);

        public Task<bool> UpdateAppointmentAsync(int appointmentId, Appointment appointment);

        public Task<List<Appointment>> GetAppointmentsByPractitionerAsync(int id);

        public Task<List<Appointment>> GetAppointmentsByPatientAsync(int id);

        public Task<Appointment> GetPatientAppointment(int patientId, int id);

        public Task<List<Appointment>> GetAppointmentsByPractitionerForLocationAsync(int id, int locationId);

        public Task<List<Appointment>> GetAppointmentByLocationAndDateRangeAsync(int id, DateTime startDate, DateTime endDate);
    }
}