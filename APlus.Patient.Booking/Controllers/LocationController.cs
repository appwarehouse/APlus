using APlus.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APlus.DataAccess;
using APlus.DataAccess.Locations;
using APlus.Patient.Booking.Interfaces;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APlus.Patient.Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IBranchesService _branchesService;

        public LocationController(IBranchesService branchesService)
        {
            _branchesService = branchesService;
        }

        // GET: api/<LocationController>
        //[Authorize]
        [HttpGet("branches/list")]
        public async Task<ActionResult<List<Location>>> GetBranches()
        {
            var listLocations = await _branchesService.GetActiveBranches();
            return listLocations.OrderBy(l=> l.LocationName).ToList();
        }

    }
}