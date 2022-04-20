using System;
using System.Collections.Generic;

namespace CRUD_Hospital.Model
{
    public partial class Medicalhistory
    {
        public Medicalhistory()
        {
            Diseases = new HashSet<Disease>();
        }

        public int MedicalhistoryId { get; set; }
        public int PatientId { get; set; }

        public virtual Patient Patient { get; set; } = null!;
        public virtual ICollection<Disease> Diseases { get; set; }
    }
}
