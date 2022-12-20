using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APlus.DataAccess
{
    public enum AppointmentStatusEnum
    {
        Booked = 1,
        Deleted = 2,
        Rescheduled = 3,
        Attended = 4,
        NoShow = 5,
        Cancelled = 6,
        AttendendStopTreatment = 7,
        CancelledStopTreatment = 8,
        AttendendComplimentary = 9
    }
}