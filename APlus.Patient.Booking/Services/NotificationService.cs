using APlus.DataAccess.Locations;
using APlus.DataAccess.Models;
using APlus.EmailClient.Services;
using APlus.Patient.Booking.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APlus.Patient.Booking.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IEmailClientSender _emailClient;

        public NotificationService(IEmailClientSender emailClient)
        {
            _emailClient = emailClient;
        }

        public async Task<bool> SendEmail(string recipient, object model, string modelName)
        {
            var assemplyPath = EmailClient.emailType.newPatientAppointmentNotification;

            if (! string.IsNullOrEmpty(modelName))
            {
                assemplyPath = EmailClient.emailType.cancelPatientAppointmentNotification;
            }

            var emailSent = await _emailClient.SendEmailToRecipient(recipient, model, assemplyPath );
            return emailSent;
        }

        public async Task<bool> SendEmail(string[] recipient, object model, string modelName, bool showEmailAddresses = false)
        {
            var assemplyPath = EmailClient.emailType.newPatientAppointmentNotification;

            if (!string.IsNullOrEmpty(modelName))
            {
                assemplyPath = EmailClient.emailType.cancelPatientAppointmentNotification;
            }

            var emailSent = await _emailClient.SendEmailToRecipients(recipient, model, assemplyPath, showEmailAddresses);
            return emailSent;
        }
    }
}