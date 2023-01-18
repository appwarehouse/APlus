using APlus.DataAccess.Database;
using APlus.DataAccess.Interfaces;
using APlus.DataAccess.Models;
using Itenso.TimePeriod;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APlus.DataAccess.Schedule
{
    internal class PublicHoliday : IPublicHolidays
    {
        private readonly PatientContext _context;

        public PublicHoliday(PatientContext context)
        {
            _context= context;
        }
        public async Task<SchedHoliday> CreatePublicHolidays(SchedHoliday publicHoliday)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePublicHolidays(int pubicHolidayId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SchedHoliday>> GetPublicHolidays(bool listOnlyActive = true)
        {
            var list=  await _context.SchedHolidays.ToListAsync();
            if (!listOnlyActive) return list;
            return list.Where(x=> x.IsActive == true);
        }

        public async Task<IEnumerable<SchedHoliday>> GetPublicHolidays(int year, bool listOnlyActive = true)
        {
            var list  = await _context.SchedHolidays.Where(x=> x.Day.Year == year).ToListAsync();
            if (!listOnlyActive) return list;
            return list.Where(x => x.IsActive == true);
        }

        public async Task<IEnumerable<SchedHoliday>> GetPublicHolidays(DateTime startDate, bool listOnlyActive = true)
        {
            var list = await _context.SchedHolidays.Where(x => x.Day >= startDate).ToListAsync();
            if (!listOnlyActive) return list;
            return list.Where(x => x.IsActive == true);
        }

        public Task<bool> UpdatePublicHolidays(SchedHoliday publicHoliday, int pubicHolidayId)
        {
            throw new NotImplementedException();
        }
    }
}
