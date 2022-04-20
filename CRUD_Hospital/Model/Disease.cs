using System;
using System.Collections.Generic;

namespace CRUD_Hospital.Model
{
    public partial class Disease
    {
        public int DiseaseId { get; set; }
        public string DName { get; set; } = null!;
        public int MedicalhistiryId { get; set; }

        public virtual Medicalhistory Medicalhistiry { get; set; } = null!;
    }
}
