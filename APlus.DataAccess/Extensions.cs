using APlus.DataAccess.Models;
using Itenso.TimePeriod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APlus.DataAccess
{
    public static class Extensions
    {
       public static TimeRange AsTimeRange(this SchedTherapistBreak therapistBreak)
        {
            return new TimeRange
            {
                Start = therapistBreak.BreakStart,
                End = therapistBreak.BreakEnd,
                Duration = (therapistBreak.BreakEnd - therapistBreak.BreakStart)
            };
        }

        public static IEnumerable<TimeRange> AsTimeRangeList(this IEnumerable<SchedTherapistBreak> therapistBreaks)
        {
            var list = new List<TimeRange>();
            foreach (var item in therapistBreaks)
            {
                list.Add(item.AsTimeRange());
            }
            return list;
        }
    }
}