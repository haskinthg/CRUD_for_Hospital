using System;
using System.Collections.Generic;

namespace CRUD_Hospital
{
    public partial class Patient
    {
        public Patient()
        {
            Medicalhistories = new HashSet<Medicalhistory>();
            Visits = new HashSet<Visit>();
        }

        public int PatientId { get; set; }
        public string PFirstname { get; set; } = null!;
        public string PSecondname { get; set; } = null!;
        public string PLastname { get; set; } = null!;
        public long? PPhone { get; set; }
        public int HospitalId { get; set; }

        public virtual Hospital Hospital { get; set; } = null!;
        public virtual ICollection<Medicalhistory> Medicalhistories { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }
    }
}
