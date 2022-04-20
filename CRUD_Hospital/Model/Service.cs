using System;
using System.Collections.Generic;

namespace CRUD_Hospital.Model
{
    public partial class Service
    {
        public int ServicedId { get; set; }
        public string SName { get; set; } = null!;
        public int SPrice { get; set; }
        public int TreatmentId { get; set; }

        public virtual Treatment Treatment { get; set; } = null!;
    }
}
