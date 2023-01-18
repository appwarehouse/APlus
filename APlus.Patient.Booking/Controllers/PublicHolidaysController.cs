using APlus.DataAccess.Models;
using APlus.Patient.Booking.DTOs;
using APlus.Patient.Booking.Services.Interfaces;
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
    public class PublicHolidaysController : ControllerBase
    {

        private readonly IPublicHolidayService _publicHolidayService;
        public PublicHolidaysController(IPublicHolidayService publicHolidayService)
        {
            _publicHolidayService= publicHolidayService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DateTime>>> GetAllPublicHolidays()
        {
            try 
            { 
                var list = await _publicHolidayService.GetHolidays();
                if (list.Any())
                    return list.Select(d => d.Day).ToList();

                return NoContent();
            }
            catch(Exception ex) { 
                return BadRequest($"We encountered a problem. {ex.Message}"); 
            }
            
        }

        // GET api/<PublicHolidays>/5
        [HttpGet("{currentDate}")]
        public async Task<ActionResult<List<DateTime>>> GetAllForwardPublicHolidays(DateTime currentDate)
        {
            try
            {
                var list = await _publicHolidayService.GetHolidays(currentDate);
                if (list != null)
                {
                    return list.Select(d=> d.Day).ToList();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"We encountered a problem. {ex.Message}");
            }
        }
    }
}
