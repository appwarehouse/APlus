using APlus.DataAccess.Models;
using System;

namespace APlus.Patient.Booking.DTOs
{
    public class PractitionerTypesLocationDto : TherapistType
    {
        public string LocationName { get; set; }
        public int LocationId { get; set; }
        public int TherapistTypeId { get; set; }

    }

    
}
