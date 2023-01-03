using APlus.DataAccess.Appointments;
using APlus.DataAccess.Database;
using APlus.DataAccess.Interfaces;
using APlus.DataAccess.Locations;
using APlus.DataAccess.PatientLeads;
using APlus.DataAccess.Practitioners;
using Microsoft.Extensions.DependencyInjection;


namespace APlus.DataAccess
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataAccessServices(this IServiceCollection services)
        {
            services.AddScoped<IAppointments, PatientAppointments>();
            services.AddScoped<IPractitionerAppointments, PractitionerAppointments>();
            services.AddScoped<ILocations, Branches>();
            services.AddScoped<IPractitionerTypes, PractitionerTypes.PractitionerTypes>();
            services.AddScoped<IDatabase, UpdateDatabase>();
            services.AddScoped<ILeads, AppointmentLeads>();
            services.AddScoped<IPatients, Patients.Patients>();
            services.AddScoped<ITreatmentTypes, TreatmentTypes.TreatmentTypes>();
            services.AddScoped<IPractitioner, Practitioner>();

        }
    }
}