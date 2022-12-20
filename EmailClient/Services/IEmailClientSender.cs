using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APlus.EmailClient.Services
{
    public interface IEmailClientSender
    {
        Task<bool> SendEmailToRecipient(string recipient, object model, emailType emailType);
    }
}