using System;
using System.Collections.Generic;

namespace CRUD_Hospital.Model
{
    public partial class Visit
    {
        public Visit()
        {
            Treatments = new HashSet<Treatment>();
        }

        public int VisitId { get; set; }
        public DateOnly VDate { get; set; }
        public TimeOnly VTine { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; } = null!;
        public virtual Patient Patient { get; set; } = null!;
        public virtual ICollection<Treatment> Treatments { get; set; }
    }
}
