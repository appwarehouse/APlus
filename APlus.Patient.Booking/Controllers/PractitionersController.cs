using APlus.Patient.Booking.DTOs;
using APlus.Patient.Booking.Interfaces;
using Itenso.TimePeriod;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APlus.Patient.Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PractitionersController : ControllerBase
    {
        private readonly IPractitionerAppointmentService _practitionerAppointmentService;

        public PractitionersController(IPractitionerAppointmentService practitionerAppointmentService)
        {
            _practitionerAppointmentService = practitionerAppointmentService;
        }

        // GET api/<PractitionersController>/5
        [HttpGet("timeslots/{practitionerId}/{startDate}/{endDate}")]
        public async Task<ActionResult<List<TimeRange>>> GetPractitionerTimeSlots(int practitionerId, DateTime startDate, DateTime endDate)
        {
           var timeSlots = await  _practitionerAppointmentService.GetPractitionerAvailableTimeslotsAsync(practitionerId, startDate, endDate);
           return timeSlots.ToList();

        }

        // GET api/<PractitionersController>/5
        [HttpGet("availability/{treatmentTypeId}/{startDate}/{locationId}")]
        public async Task<ActionResult<List<PractitionerAvailabilityDto>>> GetPractitionerAvailability(int treatmentTypeId, DateTime startDate, int locationId)
        {
            //get all practitioner Ids in this Treatment Type Id
            var timeSlots = await _practitionerAppointmentService.GetTreatmentAvailabilityByLocation(treatmentTypeId, startDate, locationId);
            return timeSlots.ToList();
        }

    }
}
