using System;
using System.Collections.Generic;

#nullable disable

namespace APlus.DataAccess.Models
{
    public partial class Patient
    {
        public Patient()
        {
            Appointments = new HashSet<Appointment>();
            BlockedPatients = new HashSet<BlockedPatient>();
            OutgoingMessages = new HashSet<OutgoingMessage>();
            PatientNotes = new HashSet<PatientNote>();
            PatientProgrammes = new HashSet<PatientProgramme>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public DateTime Dob { get; set; }
        public string Idnumber { get; set; }
        public string MedEdiaccount { get; set; }
        public int LocationId { get; set; }
        public string IntDialingCode { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string PhysicalAddress1 { get; set; }
        public string PhysicalAddress2 { get; set; }
        public string PhysicalCity { get; set; }
        public string PhysicalPostalCode { get; set; }
        public string PostalAddress1 { get; set; }
        public string PostalAddress2 { get; set; }
        public string PostalCity { get; set; }
        public string PostalPostalCode { get; set; }
        public bool IsDbc { get; set; }
        public string MedEdimedicalAidName { get; set; }
        public int? MedicalAidId { get; set; }
        public string MedicalAidPlanName { get; set; }
        public string MedicalAidOptionName { get; set; }
        public string MedicalAidNumber { get; set; }
        public string DependentNumber { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public bool IsBlocked { get; set; }

        public virtual AspNetUser CreatedByNavigation { get; set; }
        public virtual Location Location { get; set; }
        public virtual MedicalAidProvider MedicalAid { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<BlockedPatient> BlockedPatients { get; set; }
        public virtual ICollection<OutgoingMessage> OutgoingMessages { get; set; }
        public virtual ICollection<PatientNote> PatientNotes { get; set; }
        public virtual ICollection<PatientProgramme> PatientProgrammes { get; set; }
    }
}