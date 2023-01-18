using System;
using System.Collections.Generic;

#nullable disable

namespace APlus.DataAccess.Models
{
    public partial class Therapist
    {
        public Therapist()
        {
            SchedTherapistAvailabilitySchedules = new HashSet<SchedTherapistAvailabilitySchedule>();
            SchedTherapistBreaks = new HashSet<SchedTherapistBreak>();
            SchedTherapistLunchBreakExceptions = new HashSet<SchedTherapistLunchBreakException>();
            SchedTherapistLunchBreaks = new HashSet<SchedTherapistLunchBreak>();
            TherapistAppointments = new HashSet<TherapistAppointment>();
            TherapistLocations = new HashSet<TherapistLocation>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public int TherapistTypeId { get; set; }
        public bool IsActive { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string UserId { get; set; }
        public string HpcsaNumber { get; set; }
        public DateTime? HpcsaExpiryDate { get; set; }
        public string PracticeNumber { get; set; }
        public DateTime? PracticeExpiryDate { get; set; }
        public string LunchTime { get; set; }
        public int? LunchTimeDuration { get; set; }
        public string ImageUrl { get; set; }

        public virtual TherapistType TherapistType { get; set; }
        public virtual AspNetUser User { get; set; }
        public virtual ICollection<SchedTherapistAvailabilitySchedule> SchedTherapistAvailabilitySchedules { get; set; }
        public virtual ICollection<SchedTherapistBreak> SchedTherapistBreaks { get; set; }
        public virtual ICollection<SchedTherapistLunchBreakException> SchedTherapistLunchBreakExceptions { get; set; }
        public virtual ICollection<SchedTherapistLunchBreak> SchedTherapistLunchBreaks { get; set; }
        public virtual ICollection<TherapistAppointment> TherapistAppointments { get; set; }
        public virtual ICollection<TherapistLocation> TherapistLocations { get; set; }
    }
}