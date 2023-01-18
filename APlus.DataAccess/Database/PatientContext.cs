using APlus.DataAccess.Models;
using APlus.DataAccess.Models.Authentication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APlus.DataAccess.Database
{
    public class PatientContext : IdentityDbContext<ApplicationUser>
    {
        public PatientContext()
        {
        }

        public PatientContext(DbContextOptions<PatientContext> options) : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<AppointmentStatus> AppointmentStatuses { get; set; }

        //public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        //public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        //public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        //public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        //public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AuditAppointment> AuditAppointments { get; set; }

        public virtual DbSet<AuditTherapistAppointment> AuditTherapistAppointments { get; set; }
        public virtual DbSet<BlockedPatient> BlockedPatients { get; set; }
        public virtual DbSet<BranchTarget> BranchTargets { get; set; }
        public virtual DbSet<Colour> Colours { get; set; }
        public virtual DbSet<Cycle> Cycles { get; set; }
        public virtual DbSet<ErrorLog> ErrorLogs { get; set; }
        public virtual DbSet<GlobalSetting> GlobalSettings { get; set; }
        public virtual DbSet<IncomingMessage> IncomingMessages { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<LocationProgramme> LocationProgrammes { get; set; }
        public virtual DbSet<MedediPatientImportsDiscard> MedediPatientImportsDiscards { get; set; }
        public virtual DbSet<MededipatientsImport> MededipatientsImports { get; set; }
        public virtual DbSet<MedicalAidProvider> MedicalAidProviders { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistories { get; set; }
        public virtual DbSet<Otp> Otps { get; set; }
        public virtual DbSet<OutgoingMessage> OutgoingMessages { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<PatientNote> PatientNotes { get; set; }
        public virtual DbSet<PatientProgramme> PatientProgrammes { get; set; }
        public virtual DbSet<PatientsImport> PatientsImports { get; set; }
        public virtual DbSet<ProcedureCode> ProcedureCodes { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<ProfileRole> ProfileRoles { get; set; }
        public virtual DbSet<Programme> Programmes { get; set; }
        public virtual DbSet<QuartzJob> QuartzJobs { get; set; }
        public virtual DbSet<Ranking> Rankings { get; set; }
        public virtual DbSet<SchedHoliday> SchedHolidays { get; set; }
        public virtual DbSet<SchedMeeting> SchedMeetings { get; set; }
        public virtual DbSet<SchedMeetingInvitee> SchedMeetingInvitees { get; set; }
        public virtual DbSet<SchedTherapistAvailabilitySchedule> SchedTherapistAvailabilitySchedules { get; set; }
        public virtual DbSet<SchedTherapistBreak> SchedTherapistBreaks { get; set; }
        public virtual DbSet<SchedTherapistLunchBreak> SchedTherapistLunchBreaks { get; set; }
        public virtual DbSet<SchedTherapistLunchBreakException> SchedTherapistLunchBreakExceptions { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<Template> Templates { get; set; }
        public virtual DbSet<TemplateTag> TemplateTags { get; set; }
        public virtual DbSet<Therapist> Therapists { get; set; }
        public virtual DbSet<TherapistAppointment> TherapistAppointments { get; set; }
        public virtual DbSet<TherapistAppointmentNote> TherapistAppointmentNotes { get; set; }
        public virtual DbSet<TherapistAppointmentProcedureCode> TherapistAppointmentProcedureCodes { get; set; }
        public virtual DbSet<TherapistLocation> TherapistLocations { get; set; }
        public virtual DbSet<TherapistType> TherapistTypes { get; set; }
        public virtual DbSet<TherapistTypeProgramme> TherapistTypeProgrammes { get; set; }
        public virtual DbSet<Leads> Leads { get; set; }
        public virtual DbSet<VwBioAppointment> VwBioAppointments { get; set; }
        public virtual DbSet<VwBlockedPatient> VwBlockedPatients { get; set; }
        public virtual DbSet<VwDocAppointment> VwDocAppointments { get; set; }
        public virtual DbSet<VwPhysioAppointment> VwPhysioAppointments { get; set; }
        public virtual DbSet<TreatmentType> TreatmentType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //ToDo: Send up a warning flare
                var connString = "Server=.;Database=BackClinic;ConnectRetryCount=0;Trusted_Connection=True;MultipleActiveResultSets=true";
                optionsBuilder
                    .EnableSensitiveDataLogging(false)
                    .UseSqlServer(connString, options => options.MaxBatchSize(150));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("Appointment");

                entity.Property(e => e.AppointmentStatusId).HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.End).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(128);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ProgrammeId).HasDefaultValueSql("((1))");

                entity.Property(e => e.Start).HasColumnType("datetime");

                entity.HasOne(d => d.Cycle)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.CycleId)
                    .HasConstraintName("FK_Appointment_Cycle1");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Appointment_Location");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Appointment_AppointmentStatus");
            });

            modelBuilder.Entity<AppointmentStatus>(entity =>
            {
                entity.ToTable("AppointmentStatus");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CanBook)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.Name, "RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.UserName, "UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_UserId");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId })
                    .HasName("PK_dbo.AspNetUserLogins");

                entity.HasIndex(e => e.UserId, "IX_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK_dbo.AspNetUserRoles");

                entity.HasIndex(e => e.RoleId, "IX_RoleId");

                entity.HasIndex(e => e.UserId, "IX_UserId");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.RoleId).HasMaxLength(128);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AuditAppointment>(entity =>
            {
                entity.ToTable("Audit_Appointment");

                entity.Property(e => e.Action)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.End).HasColumnType("datetime");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.ModifiedById).HasMaxLength(128);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.PatientName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Start).HasColumnType("datetime");
            });

            modelBuilder.Entity<AuditTherapistAppointment>(entity =>
            {
                entity.ToTable("Audit_TherapistAppointment");

                entity.Property(e => e.Action)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.End).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Start).HasColumnType("datetime");

                entity.Property(e => e.TherapistName)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<BlockedPatient>(entity =>
            {
                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.BlockedById)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.BlockedByName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.BlockedComment)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.BlockedReason)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateBlocked).HasColumnType("datetime");

                entity.Property(e => e.DateUnblocked).HasColumnType("datetime");

                entity.Property(e => e.ReasonForUnblock).HasColumnType("text");

                entity.Property(e => e.UnblockedById).HasMaxLength(128);

                entity.Property(e => e.UnblockedByName).HasMaxLength(250);

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.BlockedPatients)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BlockedPatients_Patient");
            });

            modelBuilder.Entity<BranchTarget>(entity =>
            {
                entity.Property(e => e.MedicalAid)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<Colour>(entity =>
            {
                entity.ToTable("Colour");

                entity.Property(e => e.Colour1)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("Colour")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Cycle>(entity =>
            {
                entity.ToTable("Cycle");

                entity.Property(e => e.DischargeDate).HasColumnType("datetime");

                entity.Property(e => e.EnrollmentDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ErrorLog>(entity =>
            {
                entity.ToTable("ErrorLog");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Error)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.InnerException).HasColumnType("text");

                entity.Property(e => e.InnerExceptionMessage).HasColumnType("text");

                entity.Property(e => e.StackTrace)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.UserId).HasMaxLength(128);
            });

            modelBuilder.Entity<GlobalSetting>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("GlobalSetting");

                entity.Property(e => e.DefaultAdminAccountId).HasColumnName("DefaultAdminAccountID");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.MailPassword).HasMaxLength(50);

                entity.Property(e => e.MailServer).HasMaxLength(50);

                entity.Property(e => e.MailUserName).HasMaxLength(50);
            });

            modelBuilder.Entity<IncomingMessage>(entity =>
            {
                entity.ToTable("IncomingMessage");

                entity.Property(e => e.Message).HasColumnType("text");

                entity.Property(e => e.NumFrom).HasMaxLength(20);

                entity.Property(e => e.ReceivedDate).HasColumnType("datetime");

                entity.Property(e => e.SentDate).HasColumnType("datetime");

                entity.Property(e => e.SentMessage).HasColumnType("text");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location");

                entity.Property(e => e.AddressUrl)
                    .HasMaxLength(50)
                    .HasColumnName("AddressURL");

                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.Colour)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("(N'#14B7C3')")
                    .IsFixedLength(true);

                entity.Property(e => e.Country).HasMaxLength(100);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.LocationName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Mobile).HasMaxLength(20);

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.PostalCode).HasMaxLength(10);

                entity.Property(e => e.Province).HasMaxLength(100);
            });

            modelBuilder.Entity<LocationProgramme>(entity =>
            {
                entity.ToTable("LocationProgramme");

                entity.Property(e => e.DateAddedToProgramme).HasColumnType("datetime");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.LocationProgrammes)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LocationProgramme_Location");

                entity.HasOne(d => d.Programme)
                    .WithMany(p => p.LocationProgrammes)
                    .HasForeignKey(d => d.ProgrammeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LocationProgramme_Programme");
            });

            modelBuilder.Entity<MedediPatientImportsDiscard>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MEDediPatientImports_discard");

                entity.Property(e => e.AccountName)
                    .HasMaxLength(255)
                    .HasColumnName("Account Name");

                entity.Property(e => e.Branch).HasMaxLength(255);

                entity.Property(e => e.Cell).HasMaxLength(255);

                entity.Property(e => e.Code).HasMaxLength(255);

                entity.Property(e => e.DateOfBirth)
                    .HasMaxLength(255)
                    .HasColumnName("Date of Birth");

                entity.Property(e => e.DepNo)
                    .HasMaxLength(255)
                    .HasColumnName("Dep No");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Fax).HasMaxLength(255);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .HasColumnName("First Name");

                entity.Property(e => e.Gender).HasMaxLength(255);

                entity.Property(e => e.HomeTel)
                    .HasMaxLength(255)
                    .HasColumnName("Home Tel");

                entity.Property(e => e.IdNumber)
                    .HasMaxLength(255)
                    .HasColumnName("ID Number");

                entity.Property(e => e.Initials).HasMaxLength(255);

                entity.Property(e => e.IsDbc)
                    .HasMaxLength(255)
                    .HasColumnName("IsDBC");

                entity.Property(e => e.MedediAccountNo)
                    .HasMaxLength(255)
                    .HasColumnName("Mededi Account No");

                entity.Property(e => e.MembershipNo)
                    .HasMaxLength(255)
                    .HasColumnName("Membership No");

                entity.Property(e => e.Option).HasMaxLength(255);

                entity.Property(e => e.PatientKey)
                    .HasMaxLength(255)
                    .HasColumnName("Patient Key");

                entity.Property(e => e.Plan).HasMaxLength(255);

                entity.Property(e => e.PostalAddr1)
                    .HasMaxLength(255)
                    .HasColumnName("Postal Addr 1");

                entity.Property(e => e.PostalAddr2)
                    .HasMaxLength(255)
                    .HasColumnName("Postal Addr 2");

                entity.Property(e => e.PostalCity)
                    .HasMaxLength(255)
                    .HasColumnName("Postal City");

                entity.Property(e => e.PostalPostalCode)
                    .HasMaxLength(255)
                    .HasColumnName("Postal Postal Code");

                entity.Property(e => e.ResCity)
                    .HasMaxLength(255)
                    .HasColumnName("Res City");

                entity.Property(e => e.ResStreet1)
                    .HasMaxLength(255)
                    .HasColumnName("Res Street 1");

                entity.Property(e => e.ResStreet2)
                    .HasMaxLength(255)
                    .HasColumnName("Res Street 2");

                entity.Property(e => e.Scheme).HasMaxLength(255);

                entity.Property(e => e.Surname).HasMaxLength(255);

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.Property(e => e.WorkTel)
                    .HasMaxLength(255)
                    .HasColumnName("Work Tel");
            });

            modelBuilder.Entity<MededipatientsImport>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MEDEDIPatientsImport");

                entity.Property(e => e.AddressStreet1).HasMaxLength(250);

                entity.Property(e => e.AddressStreet2).HasMaxLength(250);

                entity.Property(e => e.Area).HasMaxLength(250);

                entity.Property(e => e.BeneficiaryNumber)
                    .HasMaxLength(50)
                    .HasColumnName("Beneficiary Number ");

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("Created By");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Dob)
                    .HasMaxLength(50)
                    .HasColumnName("DOB");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(100)
                    .HasColumnName("Email Address");

                entity.Property(e => e.Gender).HasMaxLength(20);

                entity.Property(e => e.HomeTel)
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.Property(e => e.IdNumber)
                    .HasMaxLength(20)
                    .HasColumnName("ID Number");

                entity.Property(e => e.IsDbc)
                    .HasMaxLength(50)
                    .HasColumnName("isDBC");

                entity.Property(e => e.LocationId)
                    .HasMaxLength(50)
                    .HasColumnName("Location Id");

                entity.Property(e => e.MedEdiaccount)
                    .HasMaxLength(15)
                    .HasColumnName("MedEDIAccount");

                entity.Property(e => e.MedEdipatientKey)
                    .HasMaxLength(50)
                    .HasColumnName("MedEDIPatientKey");

                entity.Property(e => e.MedicalAidId)
                    .HasMaxLength(50)
                    .HasColumnName("Medical Aid Id");

                entity.Property(e => e.MedicalAidOption).HasMaxLength(50);

                entity.Property(e => e.MedicalAidPlan).HasMaxLength(50);

                entity.Property(e => e.MedicalScheme)
                    .HasMaxLength(255)
                    .HasColumnName("Medical Scheme ");

                entity.Property(e => e.Member)
                    .HasMaxLength(30)
                    .HasColumnName("Member ");

                entity.Property(e => e.Mobile).HasMaxLength(15);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(128)
                    .HasColumnName("Modified By");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(15);

                entity.Property(e => e.PostalAddress1).HasMaxLength(250);

                entity.Property(e => e.PostalAddress2).HasMaxLength(250);

                entity.Property(e => e.PostalCity).HasMaxLength(50);

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.PostalPostalCode)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Surname).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(10);

                entity.Property(e => e.WorkTel)
                    .HasMaxLength(20)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<MedicalAidProvider>(entity =>
            {
                entity.ToTable("MedicalAidProvider");

                entity.Property(e => e.IsCash)
                    .HasColumnName("isCash")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Rank).HasDefaultValueSql("((1000))");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Otp>(entity =>
            {
                entity.ToTable("OTPs");

                entity.Property(e => e.DateSent)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ErrorMessage).HasColumnType("text");

                entity.Property(e => e.MobileNumber).HasMaxLength(20);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.UserId).HasMaxLength(128);
            });

            modelBuilder.Entity<OutgoingMessage>(entity =>
            {
                entity.ToTable("OutgoingMessage");

                entity.Property(e => e.DateSent)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmailAddress).HasMaxLength(50);

                entity.Property(e => e.ErrorMessage).HasColumnType("text");

                entity.Property(e => e.Message).HasColumnType("text");

                entity.Property(e => e.MobileNumber).HasMaxLength(20);

                entity.Property(e => e.SentByUserId).HasMaxLength(128);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.OutgoingMessages)
                    .HasForeignKey(d => d.Patientid)
                    .HasConstraintName("FK_OutgoingMessage_Patient");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("Patient");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DependentNumber)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Gender).HasMaxLength(50);

                entity.Property(e => e.Idnumber)
                    .HasMaxLength(20)
                    .HasColumnName("IDNumber");

                entity.Property(e => e.IntDialingCode)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("((27))");

                entity.Property(e => e.IsDbc).HasColumnName("IsDBC");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(128);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.MedEdiaccount)
                    .HasMaxLength(15)
                    .HasColumnName("MedEDIAccount");

                entity.Property(e => e.MedEdimedicalAidName)
                    .HasMaxLength(250)
                    .HasColumnName("MedEDIMedicalAidName");

                entity.Property(e => e.MedicalAidNumber).HasMaxLength(30);

                entity.Property(e => e.MedicalAidOptionName).HasMaxLength(250);

                entity.Property(e => e.MedicalAidPlanName).HasMaxLength(250);

                entity.Property(e => e.Mobile).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.PhysicalAddress1).HasMaxLength(250);

                entity.Property(e => e.PhysicalAddress2).HasMaxLength(250);

                entity.Property(e => e.PhysicalCity).HasMaxLength(250);

                entity.Property(e => e.PhysicalPostalCode)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.PostalAddress1).HasMaxLength(250);

                entity.Property(e => e.PostalAddress2).HasMaxLength(250);

                entity.Property(e => e.PostalCity).HasMaxLength(50);

                entity.Property(e => e.PostalPostalCode).HasMaxLength(50);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Patient_User_CreatedBy");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Patient_Location");

                entity.HasOne(d => d.MedicalAid)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.MedicalAidId)
                    .HasConstraintName("FK_Patient_MedicalAidProvider");
            });

            modelBuilder.Entity<PatientNote>(entity =>
            {
                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.NoteText)
                    .IsRequired()
                    .HasColumnType("text");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.PatientNotes)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientNotes_AspNetUsers");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.PatientNotes)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientNotes_Patient");
            });

            modelBuilder.Entity<PatientProgramme>(entity =>
            {
                entity.ToTable("PatientProgramme");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.PatientProgrammes)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientProgramme_Patient");

                entity.HasOne(d => d.Programme)
                    .WithMany(p => p.PatientProgrammes)
                    .HasForeignKey(d => d.ProgrammeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientProgramme_Programme");
            });

            modelBuilder.Entity<PatientsImport>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PatientsImport");

                entity.Property(e => e.Area).HasMaxLength(250);

                entity.Property(e => e.BeneficiaryNumber)
                    .HasMaxLength(255)
                    .HasColumnName("Beneficiary Number ");

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(128)
                    .HasColumnName("Created By");

                entity.Property(e => e.Dob)
                    .HasMaxLength(255)
                    .HasColumnName("DOB");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(100)
                    .HasColumnName("Email Address");

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.HomeTel).HasMaxLength(255);

                entity.Property(e => e.IdNumber)
                    .HasMaxLength(50)
                    .HasColumnName("ID Number");

                entity.Property(e => e.IsDbc)
                    .HasMaxLength(25)
                    .HasColumnName("isDBC");

                entity.Property(e => e.LocationId).HasColumnName("Location Id");

                entity.Property(e => e.MedEdiaccount)
                    .HasMaxLength(255)
                    .HasColumnName("MedEDIAccount");

                entity.Property(e => e.MedicalAidId)
                    .HasMaxLength(255)
                    .HasColumnName("Medical Aid Id");

                entity.Property(e => e.MedicalAidOption).HasMaxLength(255);

                entity.Property(e => e.MedicalAidPlan).HasMaxLength(255);

                entity.Property(e => e.MedicalScheme)
                    .HasMaxLength(255)
                    .HasColumnName("Medical Scheme ");

                entity.Property(e => e.Member)
                    .HasMaxLength(30)
                    .HasColumnName("Member ");

                entity.Property(e => e.Mobile).HasMaxLength(10);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(128)
                    .HasColumnName("Modified By");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(10);

                entity.Property(e => e.PostalCity).HasMaxLength(50);

                entity.Property(e => e.PostalCode).HasMaxLength(255);

                entity.Property(e => e.PostalPostalCode).HasMaxLength(255);

                entity.Property(e => e.Surname).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(10);

                entity.Property(e => e.WorkTel).HasMaxLength(255);
            });

            modelBuilder.Entity<ProcedureCode>(entity =>
            {
                entity.ToTable("ProcedureCode");

                entity.Property(e => e.ProcedureCode1)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ProcedureCode")
                    .IsFixedLength(true);

                entity.HasOne(d => d.TherapistTypeNavigation)
                    .WithMany(p => p.ProcedureCodes)
                    .HasForeignKey(d => d.TherapistType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ICD10Code_TherapistType");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.ToTable("Profile");

                entity.Property(e => e.Profile1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Profile");
            });

            modelBuilder.Entity<ProfileRole>(entity =>
            {
                entity.HasKey(e => new { e.Profile, e.Role });

                entity.HasOne(d => d.ProfileNavigation)
                    .WithMany(p => p.ProfileRoles)
                    .HasForeignKey(d => d.Profile)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProfileRoles_Profile");
            });

            modelBuilder.Entity<Programme>(entity =>
            {
                entity.ToTable("Programme");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ProgrammeName)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<QuartzJob>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Duration)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ErrorDetails).HasColumnType("text");

                entity.Property(e => e.JobName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RunEnd).HasColumnType("datetime");

                entity.Property(e => e.RunStart).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ranking>(entity =>
            {
                entity.ToTable("Ranking");

                entity.Property(e => e.RankingName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SchedHoliday>(entity =>
            {
                entity.ToTable("Sched_Holiday");

                entity.Property(e => e.Day).HasColumnType("date");

                entity.Property(e => e.Holiday)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SchedMeeting>(entity =>
            {
                entity.ToTable("Sched_Meeting");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LastMobifiedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.MeetingDescription).IsRequired();

                entity.Property(e => e.MeetingName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Start).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.SchedMeetings)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sched_Meeting_AspNetUsers");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.SchedMeetings)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sched_Meeting_Location");
            });

            modelBuilder.Entity<SchedMeetingInvitee>(entity =>
            {
                entity.ToTable("Sched_MeetingInvitees");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.Meeting)
                    .WithMany(p => p.SchedMeetingInvitees)
                    .HasForeignKey(d => d.MeetingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sched_MeetingInvitees_Sched_Meeting");
            });

            modelBuilder.Entity<SchedTherapistAvailabilitySchedule>(entity =>
            {
                entity.ToTable("Sched_TherapistAvailabilitySchedule");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.End).HasColumnType("datetime");

                entity.Property(e => e.LastMobifiedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Start).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.SchedTherapistAvailabilitySchedules)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sched_TherapistAvailabilitySchedule_AspNetUsers");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.SchedTherapistAvailabilitySchedules)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sched_TherapistAvailabilitySchedule_Location");

                entity.HasOne(d => d.Therapist)
                    .WithMany(p => p.SchedTherapistAvailabilitySchedules)
                    .HasForeignKey(d => d.TherapistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sched_TherapistAvailabilitySchedule_Therapist");
            });

            modelBuilder.Entity<SchedTherapistBreak>(entity =>
            {
                entity.ToTable("Sched_TherapistBreaks");

                entity.Property(e => e.BreakEnd).HasColumnType("datetime");

                entity.Property(e => e.BreakStart).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.SchedTherapistBreaks)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sched_TherapistBreaks_AspNetUsers");

                entity.HasOne(d => d.Therapist)
                    .WithMany(p => p.SchedTherapistBreaks)
                    .HasForeignKey(d => d.TherapistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sched_TherapistBreaks_Therapist");
            });

            modelBuilder.Entity<SchedTherapistLunchBreak>(entity =>
            {
                entity.ToTable("Sched_TherapistLunchBreaks");

                entity.Property(e => e.DayName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LunchTime)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Therapist)
                    .WithMany(p => p.SchedTherapistLunchBreaks)
                    .HasForeignKey(d => d.TherapistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sched_TherapistLunchBreaks_Therapist");
            });

            modelBuilder.Entity<SchedTherapistLunchBreakException>(entity =>
            {
                entity.ToTable("Sched_TherapistLunchBreakExceptions");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ExceptionLunchTime)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsFixedLength(true);

                entity.Property(e => e.LastMobifiedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.LunchBreak).HasColumnType("datetime");

                entity.HasOne(d => d.Therapist)
                    .WithMany(p => p.SchedTherapistLunchBreakExceptions)
                    .HasForeignKey(d => d.TherapistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sched_TherapistLunchBreakExceptions_Sched_TherapistLunchBreakExceptions");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Session");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Programme)
                    .WithMany()
                    .HasForeignKey(d => d.ProgrammeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Session_Programme");
            });

            modelBuilder.Entity<Template>(entity =>
            {
                entity.ToTable("Template");

                entity.Property(e => e.TemplateContent)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.TemplateName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TemplateTag>(entity =>
            {
                entity.HasKey(e => e.Tag);

                entity.ToTable("TemplateTag");

                entity.Property(e => e.Tag).HasMaxLength(50);

                entity.Property(e => e.IdField)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TableName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Therapist>(entity =>
            {
                entity.ToTable("Therapist");

                entity.HasIndex(e => e.Email, "UI_Email")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.HpcsaExpiryDate)
                    .HasColumnType("date")
                    .HasColumnName("hpcsaExpiryDate");

                entity.Property(e => e.HpcsaNumber)
                    .HasMaxLength(50)
                    .HasColumnName("hpcsaNumber");

                entity.Property(e => e.LunchTime).HasMaxLength(5);

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.PracticeExpiryDate)
                    .HasColumnType("date")
                    .HasColumnName("practiceExpiryDate");

                entity.Property(e => e.PracticeNumber)
                    .HasMaxLength(50)
                    .HasColumnName("practiceNumber");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.TherapistType)
                    .WithMany(p => p.Therapists)
                    .HasForeignKey(d => d.TherapistTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Therapist_TherapistType");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Therapists)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Therapist_AspNetUsers");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<TherapistAppointment>(entity =>
            {
                entity.ToTable("TherapistAppointment");

                entity.Property(e => e.End).HasColumnType("datetime");

                entity.Property(e => e.Start)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.TherapistAppointments)
                    .HasForeignKey(d => d.AppointmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TherapistAppointment_Appointment");

                entity.HasOne(d => d.Therapist)
                    .WithMany(p => p.TherapistAppointments)
                    .HasForeignKey(d => d.TherapistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TherapistAppointment_Therapist");
            });

            modelBuilder.Entity<TherapistAppointmentNote>(entity =>
            {
                entity.ToTable("TherapistAppointmentNote");

                entity.Property(e => e.CreatedDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Note).IsRequired();

                entity.Property(e => e.TherapistAppointmentId).HasComment("BookingNote or MedicalNote etc");

                entity.HasOne(d => d.TherapistAppointment)
                    .WithMany(p => p.TherapistAppointmentNotes)
                    .HasForeignKey(d => d.TherapistAppointmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TherapistAppointmentNote_TherapistAppointment");
            });

            modelBuilder.Entity<TherapistAppointmentProcedureCode>(entity =>
            {
                entity.ToTable("TherapistAppointmentProcedureCode");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.HasOne(d => d.ProcedureCode)
                    .WithMany(p => p.TherapistAppointmentProcedureCodes)
                    .HasForeignKey(d => d.ProcedureCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TherapistAppointmentICD10Code_ICD10Code");

                entity.HasOne(d => d.TherapistAppointment)
                    .WithMany(p => p.TherapistAppointmentProcedureCodes)
                    .HasForeignKey(d => d.TherapistAppointmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TherapistAppointmentICD10Code_TherapistAppointment");
            });

            modelBuilder.Entity<TherapistLocation>(entity =>
            {
                entity.HasKey(e => new { e.TherapistId, e.LocationId });

                entity.ToTable("TherapistLocation");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.TherapistLocations)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DoctorLocation_Location");

                entity.HasOne(d => d.Therapist)
                    .WithMany(p => p.TherapistLocations)
                    .HasForeignKey(d => d.TherapistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DoctorLocation_Doctor");
            });

            modelBuilder.Entity<TherapistType>(entity =>
            {
                entity.ToTable("TherapistType");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.MaxConcurrantAppointments).HasDefaultValueSql("((1))");

                entity.Property(e => e.ShortName)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.TherapistTypeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IsPortalVisible)
                .HasDefaultValue(false);
            });

            modelBuilder.Entity<TherapistTypeProgramme>(entity =>
            {
                entity.ToTable("TherapistTypeProgramme");
            });

            modelBuilder.Entity<Leads>(entity =>
            {
                entity.ToTable("Leads");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Payload)
                    .IsRequired()
                    .HasColumnType("text");
            });

            modelBuilder.Entity<TreatmentType>(entity =>
            {
                entity.ToTable("TreatmentType");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.TreatmentTypeName)
                     .IsRequired()
                     .HasMaxLength(250);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.AppointmentDuration)
                     .IsRequired();

                entity.Property(e => e.IsPortalVisible)
                     .IsRequired()
                     .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.TherapistType)
                    .WithMany(p => p.TreatmentType)
                    .HasForeignKey(d => d.TherapistTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TherapistType_TreatmentType");


            });

            modelBuilder.Entity<VwBioAppointment>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwBioAppointments");

                entity.Property(e => e.ShortName)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Therapist)
                    .IsRequired()
                    .HasMaxLength(301);
            });

            modelBuilder.Entity<VwBlockedPatient>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwBlockedPatients");

                entity.Property(e => e.BlockedById)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.BlockedByName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.BlockedComment)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.BlockedReason)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateBlocked).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<VwDocAppointment>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwDocAppointments");

                entity.Property(e => e.ShortName)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Therapist)
                    .IsRequired()
                    .HasMaxLength(301);
            });

            modelBuilder.Entity<VwPhysioAppointment>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwPhysioAppointments");

                entity.Property(e => e.ShortName)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Therapist)
                    .IsRequired()
                    .HasMaxLength(301);
            });
            base.OnModelCreating(modelBuilder);

            //OnModelCreatingPartial(modelBuilder);
        }

        //private partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}