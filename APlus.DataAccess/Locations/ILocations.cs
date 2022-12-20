using APlus.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APlus.DataAccess.Locations
{
    public interface ILocations
    {
        public Task<Location> CreateNewLocationAsync(Location location);

        public Task<bool> UpdateLocationAsync(Location location);

        public Task<IEnumerable<Location>> ListLocations(bool listOnlyActive = true);

        public Task<Location> GetLocation(int id);

        public Task<Location> GetLocation(string name);
    }
}