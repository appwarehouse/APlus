using APlus.DataAccess.Appointments;
using APlus.DataAccess.Models;
using APlus.Patient.Booking.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Itenso.TimePeriod;
using APlus.Patient.Booking.DTOs;
using APlus.DataAccess.Interfaces;

namespace APlus.Patient.Booking.Services
{
    public class PractitionerAppointmentService : IPractitionerAppointmentService
    {
        private readonly IPractitionerAppointments _practitionerAppointments;
        private readonly IPractitioner _practitioner;
        private readonly ITreatmentTypes _treatmentTypes;


        public PractitionerAppointmentService(IPractitionerAppointments practitionerAppointments, IPractitioner practitioner, ITreatmentTypes treatmentTypes)
        {
            _practitionerAppointments = practitionerAppointments;
            _practitioner= practitioner;
            _treatmentTypes= treatmentTypes;
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

        public async Task<List<TherapistAppointment>> GetAppointmentByLocationAndDateRangeAsync(int practitionerId, DateTime startDate, DateTime endDate, int locationId)
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

        public async Task<List<TimeRange>> GetPractitionerAvailableTimeslotsAsync(int practitionerId, DateTime startDate, DateTime endDate, int slotDuration)
        {
            //ToDo: start and end times from config
            var retVal = await _practitionerAppointments.GetPractitionerTimeSlots(practitionerId, startDate, new Time(7, 0, 0, 0), new Time(16, 0,0,0), slotDuration);

            return retVal.ToList();
        }

        public async Task<List<PractitionerAvailabilityDto>> GetTreatmentAvailabilityByLocation(int treatmentTypeId, DateTime startDate, int locationId)
        {
            //get practitioners for this treatment type at this location
            var practitioners = await _practitioner.GetPractitionersByLocationAndTreatmentType(locationId, treatmentTypeId);
            var treatmentType = await _treatmentTypes.GetTreatmentType(treatmentTypeId);

            List<PractitionerAvailabilityDto> availabilityList = new List<PractitionerAvailabilityDto>();

            foreach (var item in practitioners)
            {
                //ToDo: start and end times from config
                //get availability
                var availability = await _practitionerAppointments
                                    .GetPractitionerTimeSlots(item.Id, 
                                                                startDate, 
                                                                new Time(7, 0, 0, 0), 
                                                                new Time(16, 0, 0, 0), 
                                                                treatmentType.AppointmentDuration);


                if (availability.Any())
                {
                    availabilityList.Add(new PractitionerAvailabilityDto()
                    {
                        practitionerId = item.Id,
                        practitionerTypeId = item.TherapistTypeId,
                        practitionerName = $"{item.FirstName} {item.Surname}",
                        practitionerType = item.TherapistType.TherapistTypeName,
                        practitionerImageUrl = item.ImageUrl,
                        availableSlots = availability.ToAvaiableSlotList().ToArray()
                    });;
                }

            }
            
            return availabilityList;

        }

        public async Task<bool> UpdatePractitionerAppointmentAsync(TherapistAppointment appointment)
        {
            var updated = await _practitionerAppointments.UpdatePractitionerAppointmentAsync(appointment);
            return updated;
        }
    }
}