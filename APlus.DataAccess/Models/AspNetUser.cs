using System;
using System.Collections.Generic;

#nullable disable

namespace APlus.DataAccess.Models
{
    public partial class AspNetUser
    {
        public AspNetUser()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaim>();
            AspNetUserLogins = new HashSet<AspNetUserLogin>();
            AspNetUserRoles = new HashSet<AspNetUserRole>();
            PatientNotes = new HashSet<PatientNote>();
            Patients = new HashSet<Patient>();
            SchedMeetings = new HashSet<SchedMeeting>();
            SchedTherapistAvailabilitySchedules = new HashSet<SchedTherapistAvailabilitySchedule>();
            SchedTherapistBreaks = new HashSet<SchedTherapistBreak>();
            Therapists = new HashSet<Therapist>();
        }

        public string Id { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public int? LocationId { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual ICollection<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual ICollection<PatientNote> PatientNotes { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
        public virtual ICollection<SchedMeeting> SchedMeetings { get; set; }
        public virtual ICollection<SchedTherapistAvailabilitySchedule> SchedTherapistAvailabilitySchedules { get; set; }
        public virtual ICollection<SchedTherapistBreak> SchedTherapistBreaks { get; set; }
        public virtual ICollection<Therapist> Therapists { get; set; }
    }
}