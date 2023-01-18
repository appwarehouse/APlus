using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace APlus.Patient.Booking.DTOs
{
    public class PractitionerAvailabilityDto
    {
        [JsonProperty("id")]
        [JsonPropertyName("id")]
        public int practitionerId { get; set; }
        public string practitionerName { get; set; }
        public string practitionerType { get; set; }
        public int practitionerTypeId { get; set; }
        public string practitionerImageUrl { get; set; }
        public AvailableSlotDto[] availableSlots { get; set; }
    }

    
}
