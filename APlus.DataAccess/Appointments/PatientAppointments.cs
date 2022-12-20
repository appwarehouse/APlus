using APlus.DataAccess.Database;
using APlus.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APlus.DataAccess.Appointments
{
    public class PatientAppointments : IAppointments

    {
        private PatientContext _context;

        public PatientAppointments(PatientContext context)
        {
            _context = context;
        }

        public async Task<bool> CancelAppointmentAsync(int appointmentId)
        {
            try
            {
                var cancelled = await _context.Appointments.SingleOrDefaultAsync(x => x.Id == appointmentId);
                if (cancelled != null)
                {
                    cancelled.AppointmentStatusId = (int)AppointmentStatusEnum.Cancelled;
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                //ToDo: Logger
                return false;
            }
        }

        public async Task<Appointment> CreateNewAppointmentAsync(Appointment appointment)
        {
            try
            {
                await _context.Appointments.AddAsync(appointment);
                await _context.SaveChangesAsync();
                return appointment;
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not create new appointment {ex.Message}");
            }
        }

        public async Task<Appointment> GetAppointmentAsync(int appointmentId)
        {
            try
            {
                Appointment appointment = await _context.Appointments.Where(x => x.Id == appointmentId)
                                                                       .Include(x => x.Location)
                                                                       .Include(x => x.Patient)
                                                                       .Include(x => x.TherapistAppointments)
                                                                       .ThenInclude(x => x.Therapist)
                                                                       .ThenInclude(x => x.TherapistType)
                                                                       .SingleOrDefaultAsync();
                return appointment;
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not get appointment {ex.Message}");
            }
        }

        public async Task<IEnumerable<Appointment>> ListAppointmentsByDateRange(DateTime startDate, DateTime endDate)
        {
            List<Appointment> patientAppointments = await _context.Appointments.Where(x => x.Start >= startDate &&
                                                                                           x.End <= endDate)
                                                                                .ToListAsync();
            return patientAppointments;
        }

        public async Task<IEnumerable<Appointment>> ListAppointmentsByPatientId(int patientId)
        {
            List<Appointment> patientAppointments = await _context.Appointments
                                                                       .Where(x => x.Patient.Id == patientId)
                                                                       .Include(x => x.Location)
                                                                       .Include(x => x.Patient)
                                                                       .Include(x => x.TherapistAppointments)
                                                                       .ThenInclude(x => x.Therapist)
                                                                       .ThenInclude(x => x.TherapistType)
                                                                       .ToListAsync();
            return patientAppointments;
        }

        public async Task<IEnumerable<Appointment>> ListAppointmentsByLocationAndDateRange(int LocationId, DateTime startDate, DateTime endDate)
        {
            List<Appointment> patientAppointments = await _context.Appointments.Where(x => x.LocationId == LocationId &&
                                                                                           x.Start >= startDate &&
                                                                                           x.End <= endDate)
                                                                               .ToListAsync();
            return patientAppointments;
        }

        public Task<bool> UpdateAppointmentAsync(Appointment appointment)
        {
            throw new NotImplementedException();
        }
    }
}