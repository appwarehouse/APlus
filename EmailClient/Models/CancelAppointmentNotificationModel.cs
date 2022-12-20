using System;
using System.Collections.Generic;
using System.Text;

namespace APlus.EmailClient.Models
{
    public class CancelAppointmentNotificationModel
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
    }
}