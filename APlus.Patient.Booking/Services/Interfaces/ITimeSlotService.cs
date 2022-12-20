using Itenso.TimePeriod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APlus.Patient.Booking.Interfaces
{
    internal interface ITimeSlotService
    {
        public Task<List<TimeRange>> CreateAllTimeSlotsAsync(DateTime startDateTime, DateTime endDateTime, int durationInMinutes);

        public Task<List<TimeRange>> GetAvailableRangesAsync(List<TimeRange> availableTimeSlots, List<TimeRange> therapistTimeSlots);
    }
}