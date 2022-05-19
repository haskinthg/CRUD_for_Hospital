using System;
using System.Collections.Generic;

namespace CRUD_Hospital
{
    public partial class Hospital
    {
        public Hospital()
        {
            Departments = new HashSet<Department>();
            Patients = new HashSet<Patient>();
        }

        public int HospitalId { get; set; }
        public string HName { get; set; } = null!;
        public string HCity { get; set; } = null!;
        public string HAddress { get; set; } = null!;

        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
    }
}
