using APlus.DataAccess.Interfaces;
using APlus.DataAccess.Models;
using Itenso.TimePeriod;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APlus.DataAccess.Appointments
{
    public interface IPractitionerAppointments
    {
        public Task<TherapistAppointment> CreateNewPractitionerAppointmentAsync(TherapistAppointment appointment);

        public Task<List<TherapistAppointment>> CreateNewPractitionerAppointmentAsync(List<TherapistAppointment> appointments);

        public Task<bool> UpdatePractitionerAppointmentAsync(TherapistAppointment appointment);

        public Task<List<TherapistAppointment>> GetPractitionerAppointmentAsync(int appointmentId);

        public Task<IEnumerable<TherapistAppointment>> ListAppointmentsByPractitionerId(int practitionerId);

        public Task<IEnumerable<TherapistAppointment>> ListPractitionerAppointmentsByDateRange(DateTime startDate, DateTime endDate, int practitionerId);

        public Task<IEnumerable<TimeRange>> ListPractitionerAppointmentsTimeRangesByDateRange(DateTime startDate, DateTime endDate, int practitionerId);

        public Task<IEnumerable<TimeRange>> PractitionerTimeSlots(DateTime startDate, DateTime endDate, Time firstSlotStartTime, Time lastSlotEndTime, int slotDuration);
    }
}