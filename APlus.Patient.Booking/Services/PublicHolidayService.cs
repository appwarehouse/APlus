using APlus.DataAccess.Interfaces;
using APlus.DataAccess.Models;
using APlus.Patient.Booking.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APlus.Patient.Booking.Services
{
    public class PublicHolidayService:IPublicHolidayService
    {
        private readonly IPublicHolidays _publicHolidays;

        public PublicHolidayService(IPublicHolidays publicHolidays)
        {
            _publicHolidays =  publicHolidays;
        }

        public async Task<IEnumerable<SchedHoliday>> GetHolidays()
        {
            return await _publicHolidays.GetPublicHolidays();
        }

        public async Task<IEnumerable<SchedHoliday>> GetHolidays(DateTime currentDate)
        {
            return await _publicHolidays.GetPublicHolidays(currentDate);
        }
    }
}
