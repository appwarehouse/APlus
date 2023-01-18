using APlus.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APlus.DataAccess.Interfaces
{
    public interface ITreatmentProgramme
    {
        public Task<IEnumerable<Programme>> GetTreatmentProgrammes(bool listOnlyActive = true);
        public Task<Programme> GetTreatmentProgramme(int programmeId);
    }
}
