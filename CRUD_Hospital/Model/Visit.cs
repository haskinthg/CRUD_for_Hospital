using System;
using System.Collections.Generic;

namespace CRUD_Hospital
{
    public partial class Visit
    {
        public int VisitId { get; set; }
        public DateOnly VDate { get; set; }
        public TimeOnly VTine { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; } = null!;
        public virtual Patient Patient { get; set; } = null!;
        public virtual Treatment Treatment { get; set; } = null!;
    }
}
