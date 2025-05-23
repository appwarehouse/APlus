﻿using APlus.DataAccess.Models;
using APlus.Patient.Booking.DTOs;
using Itenso.TimePeriod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APlus.Patient.Booking.Interfaces
{
    public interface IPractitionerAppointmentService
    {
        public Task<List<TherapistAppointment>> CreatePractitionerAppointmentAsync(List<TherapistAppointment> newAppointments);

        public Task<TherapistAppointment> CreatePractitionerAppointmentAsync(TherapistAppointment newAppointment);

        public Task<bool> UpdatePractitionerAppointmentAsync(TherapistAppointment appointment);

        public Task<TherapistAppointment> GetPractitionerAppointmentsByPractitioinerAndAppointmentIdAsync(int practitioner, int appointmentId);

        public Task<List<TherapistAppointment>> GetPractitionerAppointmentsByAppointmentIdAsync(int appointmentId);

        public Task<List<TherapistAppointment>> GetAppointmentsByPractitionerIdAsync(int practitionerId);

        public Task<List<TherapistAppointment>> GetAppointmentByLocationAndDateRangeAsync(int practitionerId, DateTime startDate, DateTime endDate, int locationId);

        public Task<List<TimeRange>> GetPractitionerAvailableTimeslotsAsync(int practitionerId, DateTime startDate, DateTime endDate, int slotDuration);

        public Task<List<PractitionerAvailabilityDto>> GetTreatmentAvailabilityByLocation(int treatmentTypeId, DateTime startDate, int locationId);
    }
}