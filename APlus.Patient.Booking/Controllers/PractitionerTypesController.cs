using APlus.DataAccess.Models;
using APlus.Patient.Booking.Interfaces;
using APlus.Patient.Booking.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Text.Json.Serialization;
using System.Text.Json;
using APlus.Patient.Booking.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APlus.Patient.Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PractitionerTypesController : ControllerBase
    {
        private readonly IPractitionerTypeService _practitionerTypeService;
        public PractitionerTypesController(IPractitionerTypeService practitionerTypeService)
        {
            _practitionerTypeService = practitionerTypeService;
        }


        [HttpGet]
        public async Task<ActionResult<List<TherapistType>>> GetPractitionerTypes()
        {
            try
            {
                var list = await _practitionerTypeService.GetPractitionerTypes();

                if (!list.Any())
                    return NoContent();

                return list.OrderBy(c => c.TherapistTypeName).ToList();
            }
            catch (Exception ex)
            {
                return BadRequest($"We encountered a problem. {ex.Message}");
            }
        }

        [HttpGet("ByLocation", Name = "ByLocation")]
        public async Task<ActionResult<List<PractitionerTypesLocationDto>>> GetPractitionerTypesByLocation()
        {
            try
            {
                var list = await _practitionerTypeService.GetLocationsAndPractitionerTypes();

                if (!list.Any())
                    return NoContent();

                var transformedData =  list.ToPractitionerTypesWithLocation().ToList();
                return transformedData.Where(x=> x.IsPortalVisible == true).OrderBy(x=> x.TherapistTypeName).ToList();
            }
            catch (Exception ex)
            {
                return BadRequest($"We encountered a problem. {ex.Message}");
            }
        }
    }
}
