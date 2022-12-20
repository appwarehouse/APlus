using System;
using System.Collections.Generic;

#nullable disable

namespace APlus.DataAccess.Models
{
    public partial class MededipatientsImport
    {
        public string MedicalScheme { get; set; }
        public string MedicalAidId { get; set; }
        public string Member { get; set; }
        public string BeneficiaryNumber { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string EmailAddress { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string Area { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string LocationId { get; set; }
        public string IsDbc { get; set; }
        public string Title { get; set; }
        public string Dob { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string IdNumber { get; set; }
        public string MedEdiaccount { get; set; }
        public string AddressStreet1 { get; set; }
        public string AddressStreet2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string HomeTel { get; set; }
        public string WorkTel { get; set; }
        public string PostalAddress1 { get; set; }
        public string PostalAddress2 { get; set; }
        public string PostalCity { get; set; }
        public string PostalPostalCode { get; set; }
        public string MedicalAidPlan { get; set; }
        public string MedicalAidOption { get; set; }
        public string MedEdipatientKey { get; set; }
    }
}