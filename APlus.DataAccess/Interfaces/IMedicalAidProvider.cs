using APlus.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APlus.DataAccess.Interfaces
{
    public interface IMedicalAidProvider

    { 
        public Task<IEnumerable<MedicalAidProvider>> ListProviders(bool listOnlyActive = true);

    }
}
