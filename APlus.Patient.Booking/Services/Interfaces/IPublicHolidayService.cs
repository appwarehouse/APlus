using System.Threading.Tasks;
using System;
using APlus.DataAccess.Models;
using System.Collections.Generic;

namespace APlus.Patient.Booking.Services.Interfaces
{
    public interface IPublicHolidayService
    {
        public Task<IEnumerable<SchedHoliday>> GetHolidays();
        public Task<IEnumerable<SchedHoliday>> GetHolidays(DateTime currentDate);
    }
}
