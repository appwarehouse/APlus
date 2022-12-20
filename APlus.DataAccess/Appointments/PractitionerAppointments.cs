using APlus.DataAccess.Database;
using APlus.DataAccess.Models;
using Itenso.TimePeriod;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APlus.DataAccess.Appointments
{
    internal class PractitionerAppointments : IPractitionerAppointments
    {
        private readonly PatientContext _context;

        public PractitionerAppointments(PatientContext context)
        {
            _context = context;
        }

        public Task<bool> CancelAppointmentAsync(int appointmentId)
        {
            throw new NotImplementedException();
        }

        public async Task<TherapistAppointment> CreateNewPractitionerAppointmentAsync(TherapistAppointment appointment)
        {
            try
            {
                await _context.TherapistAppointments.AddAsync(appointment);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not create thereapist appointment {ex.Message}");
            }

            return appointment;
        }

        public async Task<List<TherapistAppointment>> CreateNewPractitionerAppointmentAsync(List<TherapistAppointment> appointment)
        {
            try
            {
                await _context.TherapistAppointments.AddRangeAsync(appointment);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not create thereapist appointments {ex.Message}");
            }

            return appointment;
        }

        public async Task<List<TherapistAppointment>> GetPractitionerAppointmentAsync(int appointmentId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TherapistAppointment>> ListAppointmentsByPractitionerId(int practitionerId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TherapistAppointment>> ListPractitionerAppointmentsByDateRange(DateTime startDate, DateTime endDate, int practitionerId)
        {
            var appointments = await _context.TherapistAppointments.Where(x => x.Start.Date >= startDate.Date && x.End.Date <= endDate.Date && x.TherapistId == practitionerId).ToListAsync();

            return appointments;
        }

        public async Task<IEnumerable<TimeRange>> ListPractitionerAppointmentsTimeRangesByDateRange(DateTime startDate, DateTime endDate, int practitionerId)
        {
            var appointments = await ListPractitionerAppointmentsByDateRange(startDate, endDate, practitionerId);

            List<TimeRange> timeRanges = new List<TimeRange>();

            appointments.ToList().ForEach(x => timeRanges.Add(new TimeRange()
            {
                Start = x.Start,
                End = x.End,
                Duration = new TimeSpan(0, (int)x.Duration, 0)
            }));

            return timeRanges;
        }

        public async Task<IEnumerable<TimeRange>> PractitionerTimeSlots(DateTime startDate, DateTime endDate, Time firstSlotStartTime, Time lastSlotEndTime, int slotDuration)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdatePractitionerAppointmentAsync(TherapistAppointment appointment)
        {
            try
            {
                var practitionerAppointment = await _context.TherapistAppointments.SingleAsync(x => x.Id == appointment.Id);
                if (practitionerAppointment != null)
                {
                    practitionerAppointment.Start = appointment.Start;
                    practitionerAppointment.End = appointment.End;
                    practitionerAppointment.TherapistId = appointment.TherapistId;
                    practitionerAppointment.Duration = appointment.Duration;
                    practitionerAppointment.TherapistAppointmentNotes = appointment.TherapistAppointmentNotes;

                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not update thereapist appointments {ex.Message}");
            }
        }
    }
}