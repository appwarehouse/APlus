using System;
using System.Collections.Generic;

#nullable disable

namespace APlus.DataAccess.Models
{
    public partial class MedicalAidProvider
    {
        public MedicalAidProvider()
        {
            Patients = new HashSet<Patient>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public int Rank { get; set; }
        public bool? IsCash { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
    }
}