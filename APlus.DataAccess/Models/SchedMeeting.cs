using System;
using System.Collections.Generic;

#nullable disable

namespace APlus.DataAccess.Models
{
    public partial class SchedMeeting
    {
        public SchedMeeting()
        {
            SchedMeetingInvitees = new HashSet<SchedMeetingInvitee>();
        }

        public int Id { get; set; }
        public int LocationId { get; set; }
        public string MeetingName { get; set; }
        public string MeetingDescription { get; set; }
        public DateTime Start { get; set; }
        public int Duration { get; set; }
        public bool AllDay { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastMobifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public bool Active { get; set; }

        public virtual AspNetUser CreatedByNavigation { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<SchedMeetingInvitee> SchedMeetingInvitees { get; set; }
    }
}