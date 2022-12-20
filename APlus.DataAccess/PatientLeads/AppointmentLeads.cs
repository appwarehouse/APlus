using APlus.DataAccess.Database;
using APlus.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APlus.DataAccess.PatientLeads
{
    internal class AppointmentLeads : ILeads
    {
        private PatientContext _context;

        public AppointmentLeads(PatientContext context)
        {
            _context = context;
        }

        public async Task<Leads> CreateLeadAsync(Leads leadDetails)
        {
            await _context.Leads.AddAsync(leadDetails);
            await _context.SaveChangesAsync();
            return leadDetails;
        }

        public async Task<bool> DeleteLeadAsync(Guid leadId)
        {
            var lead = await _context.Leads.SingleOrDefaultAsync(x => x.Id == leadId);
            _context.Leads.Remove(lead);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}