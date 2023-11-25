using APlus.DataAccess.Interfaces;
using APlus.DataAccess.Models;
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
    public class MedicalAidController : ControllerBase

    {
        private readonly IMedicalAidProvider _medicalAidProvider;
        public MedicalAidController(IMedicalAidProvider medicalAidProvider)
        {
            _medicalAidProvider= medicalAidProvider;    
        }
        // GET: api/<MedicalAidController>
        [HttpGet("list")]
        public async Task<ActionResult<List<MedicalAidProvider>>> GetMedicalAidProviders()
        {
            try 
            { 
                var providers = await _medicalAidProvider.ListProviders();
                if (!providers.Any())
                    return NoContent();
                    return providers.ToList();
            }
            catch(Exception ex) 
            {
                return BadRequest($"We could not get the medical aid providers. {ex.Message}");
            }
        }

   
    }
}
