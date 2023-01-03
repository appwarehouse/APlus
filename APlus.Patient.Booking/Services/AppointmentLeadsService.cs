using APlus.DataAccess.Interfaces;
using APlus.DataAccess.Models;
using APlus.Patient.Booking.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APlus.Patient.Booking.Services
{
    public class AppointmentLeadsService : IAppointmentLeadsService
    {
        private readonly ILeads _leads;

        public AppointmentLeadsService(ILeads leads)
        {
            _leads = leads;
        }

        public async Task<bool> CreateAppointmentLeadAsync(Leads newLead)
        {
            _ = _leads.CreateLeadAsync(newLead);
            return true;
        }

        public async Task<bool> DeleteAppointmentLeadAsync(Guid leadId)
        {
            _ = await _leads.DeleteLeadAsync(leadId);
            return true;
        }
    }
}