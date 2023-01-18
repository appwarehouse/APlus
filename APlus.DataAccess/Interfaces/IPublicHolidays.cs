using APlus.DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APlus.DataAccess.Interfaces
{
    public interface IPublicHolidays
    {
        public Task<IEnumerable<SchedHoliday>> GetPublicHolidays(bool listOnlyActive = true);

        public Task<IEnumerable<SchedHoliday>> GetPublicHolidays(int year, bool listOnlyActive = true);

        public Task<IEnumerable<SchedHoliday>> GetPublicHolidays(DateTime startDate, bool listOnlyActive = true);

        public Task<SchedHoliday> CreatePublicHolidays(SchedHoliday publicHoliday);

        public Task<bool> UpdatePublicHolidays(SchedHoliday publicHoliday, int pubicHolidayId);

        public Task<bool> DeletePublicHolidays(int pubicHolidayId);


    }
}
