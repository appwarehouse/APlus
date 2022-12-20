using System;
using System.Collections.Generic;

#nullable disable

namespace APlus.DataAccess.Models
{
    public partial class Location
    {
        public Location()
        {
            Appointments = new HashSet<Appointment>();
            LocationProgrammes = new HashSet<LocationProgramme>();
            Patients = new HashSet<Patient>();
            SchedMeetings = new HashSet<SchedMeeting>();
            SchedTherapistAvailabilitySchedules = new HashSet<SchedTherapistAvailabilitySchedule>();
            TherapistLocations = new HashSet<TherapistLocation>();
        }

        public int Id { get; set; }
        public string LocationName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Colour { get; set; }
        public string AddressUrl { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<LocationProgramme> LocationProgrammes { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
        public virtual ICollection<SchedMeeting> SchedMeetings { get; set; }
        public virtual ICollection<SchedTherapistAvailabilitySchedule> SchedTherapistAvailabilitySchedules { get; set; }
        public virtual ICollection<TherapistLocation> TherapistLocations { get; set; }
    }
}