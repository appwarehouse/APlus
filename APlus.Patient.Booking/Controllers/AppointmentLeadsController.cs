using APlus.DataAccess.Models;
using APlus.Patient.Booking.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APlus.Patient.Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentLeadsController : ControllerBase
    {
        private readonly IAppointmentLeadsService _leadsService;

        public AppointmentLeadsController(IAppointmentLeadsService leadsService)
        {
            _leadsService = leadsService;
        }

        // POST api/<AppointmentLeadsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Leads value)
        {
            //get uuid of transaction
            var saved = await _leadsService.CreateAppointmentLeadAsync(value);
            if (saved)
                return Ok(saved);
            return BadRequest(saved);
        }

        // DELETE api/<AppointmentsController>/5
        [HttpDelete("{leadId}")]
        public async Task<ActionResult> CancelPatientAppointment(Guid leadId)
        {
            //get uuid of transaction
            var saved = await _leadsService.DeleteAppointmentLeadAsync(leadId);
            if (saved)
                return Ok();
            return BadRequest();
        }
    }
}