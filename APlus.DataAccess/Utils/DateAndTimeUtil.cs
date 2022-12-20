using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APlus.DataAccess
{
    public static class DateAndTimeUtil
    {
        public static DateTime SetTime(DateTime date, string time)
        {
            String strDate = date.ToString("dd MMM yyyy");
            DateTime newSetTime = Convert.ToDateTime($"{strDate} {time}");
            return newSetTime;
        }
    }
}