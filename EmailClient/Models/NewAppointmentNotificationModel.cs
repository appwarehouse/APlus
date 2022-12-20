using System;
using System.Collections.Generic;
using System.Text;

namespace APlus.EmailClient.Models
{
    public class NewAppointmentNotificationModel
    {
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }
        public string BranchName { get; set; }
        public string PractitionerType { get; set; }
        public string TreatmentType { get; set; }
        public string TreatmentSubType { get; set; }
        public string PractitionerName { get; set; }
        public string AppointmentDate { get; set; }
        public string AppointmentTime { get; set; }
        public string Address { get; set; }
        public string Directions { get; set; }
        public string CancelUrl { get; set; }
        public string DetailsUrl { get; set; }
    }
}