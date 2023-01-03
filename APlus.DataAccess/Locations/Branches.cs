using APlus.DataAccess.Database;
using APlus.DataAccess.Interfaces;
using APlus.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APlus.DataAccess.Locations
{
    internal class Branches : ILocations
    {
        private PatientContext _context;

        public Branches(PatientContext context)
        {
            _context = context;
        }

        public Task<Location> CreateNewLocationAsync(Location location)
        {
            throw new NotImplementedException();
        }

        public async Task<Location> GetLocation(int id)
        {
            return await _context.Locations.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Location> GetLocation(string name)
        {
            return await _context.Locations.SingleOrDefaultAsync(x => x.LocationName.ToLower() == name.ToLower());
        }

        public async Task<IEnumerable<Location>> ListLocations(bool listOnlyActive = true)
        {
            var allLocations = await _context.Locations.ToListAsync();
            if (!listOnlyActive)
                return allLocations;

            return allLocations.Where(x => x.IsActive == true && x.Id > 0).ToList();
        }

        public Task<bool> UpdateLocationAsync(Location location)
        {
            throw new NotImplementedException();
        }
    }
}