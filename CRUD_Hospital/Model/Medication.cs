using System;
using System.Collections.Generic;

namespace CRUD_Hospital.Model
{
    public partial class Medication
    {
        public int MedicationId { get; set; }
        public string MName { get; set; } = null!;
        public int TreatmentId { get; set; }

        public virtual Treatment Treatment { get; set; } = null!;
    }
}
