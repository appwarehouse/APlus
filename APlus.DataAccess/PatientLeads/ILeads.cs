using APlus.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APlus.DataAccess.PatientLeads
{
    public interface ILeads
    {
        public Task<Leads> CreateLeadAsync(Leads leadDetails);

        public Task<bool> DeleteLeadAsync(Guid leadId);
    }
}