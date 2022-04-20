using System;
using System.Collections.Generic;

namespace CRUD_Hospital.Model
{
    public partial class Department
    {
        public Department()
        {
            Doctors = new HashSet<Doctor>();
        }

        public int DepartmentId { get; set; }
        public string DName { get; set; } = null!;
        public int HospitalId { get; set; }

        public virtual Hospital Hospital { get; set; } = null!;
        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
