using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APlus.EmailClient.Models;
using APlus.EmailClient;

namespace APlus.Patient.Booking.Interfaces
{
    public interface INotificationService
    {
        public Task<bool> SendEmail(string recipient, object model, string modelName);
    }
}