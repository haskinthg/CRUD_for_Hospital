using System;
using System.Collections.Generic;

namespace CRUD_Hospital
{
    public partial class Treatment
    {
        public Treatment()
        {
            Medications = new HashSet<Medication>();
            Services = new HashSet<Service>();
        }

        public int TreatmentId { get; set; }
        public short Countdays { get; set; }
        public int VisitId { get; set; }

        public virtual Visit Visit { get; set; } = null!;
        public virtual ICollection<Medication> Medications { get; set; }
        public virtual ICollection<Service> Services { get; set; }
    }
}
