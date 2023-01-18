using APlus.DataAccess.Models;
using APlus.Patient.Booking.DTOs;
using APlus.Patient.Booking.Interfaces;
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
    public class TreatmentTypesController : ControllerBase
    {
        private readonly ITreatmentTypesService _treatmentTypesService;
        public TreatmentTypesController(ITreatmentTypesService treatmentTypesService) 
        {
            _treatmentTypesService = treatmentTypesService;           
        }

        [HttpGet]
        public async Task<ActionResult<List<TreatmentType>>> GetTreatmentTypes()
        {            
            try
            {
                var list = await _treatmentTypesService.GetTreatmentTypes();
                
                if (!list.Any())
                    return NoContent();

                return list.OrderBy(t=> t.TreatmentTypeName).ToList();
            }
            catch (Exception ex)
            {
                return BadRequest($"We encountered a problem. {ex.Message}");
            }
        }
    }
}
