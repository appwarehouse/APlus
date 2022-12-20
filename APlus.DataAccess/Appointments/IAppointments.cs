using APlus.DataAccess.Interfaces;
using APlus.DataAccess.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APlus.DataAccess.Appointments
{
    public interface IAppointments
    {
        public Task<Appointment> CreateNewAppointmentAsync(Appointment appointment);

        public Task<bool> UpdateAppointmentAsync(Appointment appointment);

        public Task<bool> CancelAppointmentAsync(int appointmentId);

        public Task<Appointment> GetAppointmentAsync(int appointmentId);

        public Task<IEnumerable<Appointment>> ListAppointmentsByPatientId(int patientId);

        public Task<IEnumerable<Appointment>> ListAppointmentsByDateRange(DateTime startDate, DateTime endDate);

        public Task<IEnumerable<Appointment>> ListAppointmentsByLocationAndDateRange(int LocationId, DateTime startDate, DateTime endDate);
    }

    //    public interface IAppointments<T> where T : IAppointmentModel
    //    {
    //        public Task<T> CreateNewAppointmentAsync(T appointment);

    //        public Task<bool> UpdateAppointmentAsync(T appointment);

    //        public Task<bool> CancelAppointmentAsync(int appointmentId);

    //        public Task<T> GetAppointmentAsync(int appointmentId);

    //        public Task<IEnumerable<T>> ListAppointmentsById(int modelId);

    //        public Task<IEnumerable<T>> ListAppointmentsByDateRange(DateTime startDate, DateTime endDate);

    //        public Task<IEnumerable<T>> ListAppointmentsByLocationAndDateRange(int LocationId, DateTime startDate, DateTime endDate);
    //    }
}