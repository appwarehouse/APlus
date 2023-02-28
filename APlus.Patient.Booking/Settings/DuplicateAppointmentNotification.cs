namespace APlus.Patient.Booking.Settings
{
    public class DuplicateAppointmentNotification
    {
        public bool SendDuplicate { get; set; }
        public string SentDuplicateTo { get; set; }
        public bool ShowAllEmails { get; set; }
    }
}
