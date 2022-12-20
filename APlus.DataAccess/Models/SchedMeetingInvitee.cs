using System;
using System.Collections.Generic;

#nullable disable

namespace APlus.DataAccess.Models
{
    public partial class SchedMeetingInvitee
    {
        public int Id { get; set; }
        public int MeetingId { get; set; }
        public int TherapistId { get; set; }
        public string UserId { get; set; }

        public virtual SchedMeeting Meeting { get; set; }
    }
}