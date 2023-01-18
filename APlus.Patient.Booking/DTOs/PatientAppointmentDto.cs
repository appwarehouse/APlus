using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace APlus.Patient.Booking.DTOs
{
    public class PatientAppointmentDto
    {
        [JsonProperty("id")]
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonProperty("appointmentId")]
        [JsonPropertyName("appointmentId")]
        public int AppointmentId { get; set; }

        [JsonProperty("name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonProperty("surname")]
        [JsonPropertyName("surname")]
        public string Surname { get; set; }

        [JsonProperty("appointmentDate")]
        [JsonPropertyName("appointmentDate")]
        public DateTime AppointmentDate { get; set; }

        [JsonProperty("gender")]
        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonProperty("dob")]
        [JsonPropertyName("dob")]
        public DateTime DoB { get; set; }

        [JsonProperty("appointmentStatus")]
        [JsonPropertyName("appointmentStatus")]
        public string AppointmentStatus { get; set; }

        [JsonProperty("end")]
        [JsonPropertyName("end")]
        public string End { get; set; }

        [JsonProperty("start")]
        [JsonPropertyName("start")]
        public string Start { get; set; }

        [JsonProperty("idNumber")]
        [JsonPropertyName("idNumber")]
        public string IdNumber { get; set; }

        [JsonProperty("idType")]
        [JsonPropertyName("idType")]
        public string IdType { get; set; }

        [JsonProperty("locationId")]
        [JsonPropertyName("locationId")]
        public int LocationId { get; set; }

        [JsonProperty("locationName")]
        [JsonPropertyName("locationName")]
        public string LocationName { get; set; }

        [JsonProperty("mobileNumber")]
        [JsonPropertyName("mobileNumber")]
        public string MobileNumber { get; set; }

        [JsonProperty("passportNumber")]
        [JsonPropertyName("passportNumber")]
        public string PassportNumber { get; set; }

        [JsonProperty("practitionerId")]
        [JsonPropertyName("practitionerId")]
        public int PractitionerId { get; set; }

        [JsonProperty("practitionerName")]
        [JsonPropertyName("practitionerName")]
        public string PractitionerName { get; set; }

        [JsonProperty("practitionerType")]
        [JsonPropertyName("practitionerType")]
        public int PractitionerType { get; set; }

        [JsonProperty("treatment")]
        [JsonPropertyName("treatment")]
        public string Treatment { get; set; }

        [JsonProperty("treatmentType")]
        [JsonPropertyName("treatmentType")]
        public string TreatmentType { get; set; }

        [JsonProperty("emailAddress")]
        [JsonPropertyName("emailAddress")]
        public string EmailAddress { get; set; }

        [JsonProperty("programme")]
        [JsonPropertyName("programme")]
        public int Programme { get; set; }
    }
}