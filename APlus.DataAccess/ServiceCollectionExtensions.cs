using APlus.DataAccess.Appointments;
using APlus.DataAccess.Database;
using APlus.DataAccess.Locations;
using APlus.DataAccess.Models;
using APlus.DataAccess.PatientLeads;
using APlus.DataAccess.Patients;
using APlus.DataAccess.Practitioners;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APlus.DataAccess
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataAccessServices(this IServiceCollection services)
        {
            services.AddScoped<IAppointments, PatientAppointments>();
            services.AddScoped<IPractitionerAppointments, PractitionerAppointments>();
            services.AddScoped<ILocations, Branches>();
            services.AddScoped<IPractitionerTypes, PractitionerTypes>();
            services.AddScoped<IDatabase, UpdateDatabase>();
            services.AddScoped<ILeads, AppointmentLeads>();
            services.AddScoped<IPatients, Patients.Patients>();
        }
    }
}