using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APlus.DataAccess.Models;

namespace APlus.Patient.Booking.Interfaces
{
    public interface IAppointmentLeadsService
    {
        public Task<bool> CreateAppointmentLeadAsync(Leads newLead);

        public Task<bool> DeleteAppointmentLeadAsync(Guid leadId);
    }
}