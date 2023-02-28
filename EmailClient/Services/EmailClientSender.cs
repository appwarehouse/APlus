using APlus.EmailClient.Helpers;
using APlus.EmailClient.Models;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APlus.EmailClient.Services
{
    public class EmailClientSender : IEmailClientSender
    {
        private readonly EmailSettings _emailSettings;

        public EmailClientSender(IOptions<EmailSettings> emailSettings)
        {
            this._emailSettings = emailSettings.Value;
        }

        public async Task<bool> SendEmailToRecipient(string recipient, object model, emailType emailType)
        {
            try
            {
                string template = GetTemplate(emailType);

                RazorParser renderer = new RazorParser(typeof(EmailClient).Assembly);
                var body = renderer.UsingTemplateFromEmbedded(template, model);

                return await SendEmailAsync(recipient, $"A7 Health Appointment Details", body);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> SendEmailToRecipients(string[] recipients, object model, emailType emailType, bool showEmails)
        {
            try
            {
                string template = GetTemplate(emailType);

                RazorParser renderer = new RazorParser(typeof(EmailClient).Assembly);
                var body = renderer.UsingTemplateFromEmbedded(template, model);

                return await SendEmailAsync(recipients, $"A7 Health Appointment Details", body, showEmails);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        private string GetTemplate(emailType emailType)
        {
            switch (emailType)
            {
                case emailType.newPatientAppointmentNotification:
                    return "Templates.NewPatientAppointmentNotificationTemplate";

                case emailType.cancelPatientAppointmentNotification:
                    return "Templates.CancelPatientAppointmentNotificationTemplate";

                default:
                    return "";
            }
        }

        private async Task<bool> SendEmailAsync(string email, string subject, string message)
        {
            var client = new SendGridClient(_emailSettings.ApiKey);
            var from = new EmailAddress(_emailSettings.From);
            var to = new EmailAddress(email);
            var plainTextContent = "";
            var htmlContent = message;

            var msg = MailHelper.CreateSingleEmail(from, to , subject, plainTextContent, htmlContent);
            Response response;
            try
            {
                response = await client.SendEmailAsync(msg);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    return true;
                return false;
            }
            catch (HttpRequestException)
            {
                //log error in logger
                throw;
            }
        }

        public async Task<bool> SendEmailAsync(string[] email, string subject, string message, bool showEmailAddressToAll)
        {
            var client = new SendGridClient(_emailSettings.ApiKey);
            var from = new EmailAddress(_emailSettings.From);
            var to = new List<EmailAddress>();
            foreach (var emailItem in email) {to.Add(new EmailAddress(emailItem)); }
           
            var plainTextContent = "";
            var htmlContent = message;

            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, to, subject, plainTextContent, htmlContent, showEmailAddressToAll);
            Response response;
            try
            {
                response = await client.SendEmailAsync(msg);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    return true;
                return false;
            }
            catch (HttpRequestException)
            {
                //log error in logger
                throw;
            }
        }
    }
}