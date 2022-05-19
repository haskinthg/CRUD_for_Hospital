using System;
using System.Collections.Generic;

namespace CRUD_Hospital
{
    public partial class Medicalhistory
    {
        public int MedicalhistoryId { get; set; }
        public int PatientId { get; set; }

        public virtual Patient Patient { get; set; } = null!;
        public virtual Disease Disease { get; set; } = null!;
    }
}
