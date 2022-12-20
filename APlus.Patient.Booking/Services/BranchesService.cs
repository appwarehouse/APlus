using APlus.DataAccess.Locations;
using APlus.DataAccess.Models;
using APlus.Patient.Booking.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APlus.Patient.Booking.Services
{
    public class BranchesService : IBranchesService
    {
        private readonly ILocations _branches;

        public BranchesService(ILocations branches)
        {
            _branches = branches;
        }

        public async Task<List<Location>> GetActiveBranches()
        {
            var branches = await _branches.ListLocations();
            return branches.ToList();
        }

        public async Task<Location> GetBranch(int locationId)
        {
            return await _branches.GetLocation(locationId);
        }

        public async Task<Location> GetBranch(string locationName)
        {
            return await _branches.GetLocation(locationName);
        }
    }
}