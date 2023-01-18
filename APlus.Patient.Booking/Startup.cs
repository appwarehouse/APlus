using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APlus.DataAccess.Database;
using APlus.DataAccess.Models.Authentication;
using Microsoft.AspNetCore.Identity;
using APlus.Patient.Booking.Interfaces;
using APlus.Patient.Booking.Services;
using APlus.DataAccess.Appointments;
using APlus.DataAccess.Models;
using APlus.DataAccess;
using Newtonsoft;
using System.Text.Json;
using APlus.EmailClient.Services;
using APlus.EmailClient;
using APlus.Patient.Booking.Services.Interfaces;

namespace APlus.Patient.Booking
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //CORS
            services.AddCors(options =>
            {
                options.AddPolicy("Default",
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                    });
            });

            //services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<PatientContext>();

            services.AddDbContext<PatientContext>(options =>
            {
                var connectionString = Configuration.GetConnectionString("PatientDb");
                options.UseSqlServer(connectionString);
            });
            services.AddDataAccessServices();
            services.AddScoped<IBranchesService, BranchesService>();
            services.AddScoped<IDatabaseUpdaterService, DatabaseUpdaterService>();
            services.AddScoped<IAppointmentService, PatientAppointmentService>();
            services.AddScoped<IPractitionerAppointmentService, PractitionerAppointmentService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IAppointmentLeadsService, AppointmentLeadsService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IPublicHolidayService, PublicHolidayService>();
            services.AddScoped<ITreatmentTypesService, TreatmentTypeService>();
            services.AddScoped<IPractitionerTypeService, PractitionerTypeService>();

            var emailSettings = Configuration.GetSection("EmailSettings");
            services.Configure<EmailSettings>(emailSettings);
            services.AddTransient<IEmailClientSender, EmailClientSender>();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "APlus.Patient.Booking", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDatabaseUpdaterService databaseUpdaterService)
        {
            databaseUpdaterService.RunDatabaseMigration();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "APlus.Patient.Booking v1"));
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("Default");
            app.UseAuthorization();
            //app.UseSentryTracing();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}