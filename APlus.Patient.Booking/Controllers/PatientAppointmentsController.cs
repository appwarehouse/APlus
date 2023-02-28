using APlus.DataAccess.Models;
using APlus.Patient.Booking.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APlus.Patient.Booking.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using APlus.EmailClient;
using APlus.Patient.Booking.Settings;
using Microsoft.Extensions.Options;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APlus.Patient.Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientAppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly INotificationService _notificationService;
        private readonly IBranchesService _branchService;
        private readonly IAppointmentLeadsService _leadsService;
        private readonly IPatientService _patientService;
        private readonly IPractitionerAppointmentService _practitionerAppointmentService;
        private readonly DuplicateAppointmentNotification _duplicateNotificationSettings;

        public PatientAppointmentsController(IAppointmentService patientAppointmentService,
            INotificationService notificationService,
            IBranchesService branchService,
             IAppointmentLeadsService leadsService,
             IPatientService patientService,
             IPractitionerAppointmentService practitionerAppointmentService,
             IOptions<DuplicateAppointmentNotification> duplicateNotificationSettings)
        {
            _appointmentService = patientAppointmentService;
            _notificationService = notificationService;
            _branchService = branchService;
            _leadsService = leadsService;
            _patientService = patientService;
            _practitionerAppointmentService = practitionerAppointmentService;
            _duplicateNotificationSettings = duplicateNotificationSettings.Value;
        }

        // GET api/<PatientAppointmentsController>/5
        [HttpGet("list/{id}")]
        public async Task<ActionResult<List<PatientAppointmentDto>>> GetPatientAppointments(int id)
        {
            try
            {
                var appointments = await _appointmentService.GetAppointmentsByPatientAsync(id);

                if (!appointments.Any())
                    return NoContent();

                return appointments.AsListDto();
            }
            catch (Exception ex)
            {
                return BadRequest($"We could not book your appointment at this time. {ex.Message}");
            }
        }

        // GET api/<PatientAppointmentsController>/5
        [HttpGet("{patientId}/{id}")]
        public async Task<ActionResult<PatientAppointmentDto>> GetPatientAppointment(int patientId, int id)
        {
            try
            {
                var appointment = await _appointmentService.GetPatientAppointment(patientId, id);

                if (appointment == null)
                    return NotFound("We could not get your appointment details.");

                return appointment.AsPatientAppointmentDto();
            }
            catch (Exception ex)
            {
                return BadRequest("Ooops something went wrong");
            }
        }

        // POST api/<AppointmentsController>
        [HttpPost]
        public async Task<ActionResult<Appointment>> Post([FromBody] PatientAppointmentDto appointmentDto)
        {
            try
            {
                var url = HttpContext.Request.Headers["origin"];
                var branch = await _branchService.GetBranch(appointmentDto.LocationId);
                int[] programmes = new int[1];
                programmes[0] = appointmentDto.Programme;
                //check if patient exists
                DataAccess.Models.Patient patient = await _patientService.FindPatientByIdNumber(appointmentDto.IdType.ToLower() == "id" ?
                    appointmentDto.IdNumber :
                    appointmentDto.PassportNumber);

                if (patient == null)
                {
                    //create new paient record
                    patient = appointmentDto.ToPatient(branch);
                    _ = await _patientService.CreatePatientRecordAsync(patient, programmes);
                }

                var appointment = appointmentDto.AsAppointment(patient.Id);
                var newAppointment = await _appointmentService.CreateAppointmentAsync(appointment);

                if (newAppointment.Id > 0)
                {
                    //create therapist appointments

                    var therapistAppointment = appointmentDto.AsPractitionerAppointment(patient.Id, newAppointment.Id);
                    _ = await _practitionerAppointmentService.CreatePractitionerAppointmentAsync(therapistAppointment);

                    //email patient
                    var emailData = appointmentDto.ToNotification(branch, appointment, url);
                    //var deleteLead = await _leadsService.DeleteAppointmentLeadAsync(appointmentDto.Id);

                    //send email to patient
                    if (_duplicateNotificationSettings.SendDuplicate)
                    {
                        string[] recipients = { appointmentDto.EmailAddress, _duplicateNotificationSettings.SentDuplicateTo };
                        _ = await _notificationService.SendEmail(recipients, emailData, "", _duplicateNotificationSettings.ShowAllEmails);
                    }
                    else
                    {
                        _ = await _notificationService.SendEmail(appointmentDto.EmailAddress, emailData, "");
                    }
                }

                return Ok(newAppointment.Id);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest("We could not book your appointment at this time");
            }
        }

        // PUT api/<PatientAppointmentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AppointmentsController>/5
        [HttpDelete("{appointmentId}")]
        public async Task<ActionResult<bool>> CancelPatientAppointment(int appointmentId)
        {
            var response = await _appointmentService.CancelAppointmentAsync(appointmentId);
            if (response) return Ok(response);
            return BadRequest(response);
        }
    }
}