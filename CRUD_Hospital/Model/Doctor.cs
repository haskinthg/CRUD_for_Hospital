using System;
using System.Collections.Generic;

namespace CRUD_Hospital
{
    public partial class Doctor
    {
        public Doctor()
        {
            Visits = new HashSet<Visit>();
        }

        public int DoctorId { get; set; }
        public string DFisrtname { get; set; } = null!;
        public string DSecondname { get; set; } = null!;
        public string DLastname { get; set; } = null!;
        public long? DPhone { get; set; }
        public string DJobtitle { get; set; } = null!;
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; } = null!;
        public virtual ICollection<Visit> Visits { get; set; }
    }
}
