using APlus.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APlus.Patient.Booking.Interfaces
{
    public interface IBranchesService
    {
        public Task<List<Location>> GetActiveBranches();

        public Task<Location> GetBranch(int locationId);

        public Task<Location> GetBranch(string name);
    }
}