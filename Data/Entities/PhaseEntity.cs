using System;
using System.Collections.Generic;
using System.Text;

namespace Smooth.Power.Data.Entities
{
    public class PhaseEntity : BaseEntity
    {
        public double Voltage { get; set; }
        public double Current { get; set; }
        public double PFCurrently { get; set; }
        public double PFCorrectedFor { get; set; }
        public double PowerUsage { get; set; }
        public double VAHUsedThisMonthToDate { get; set; }
        public double VAHSavedThisMonthToDate { get; set; }
        public virtual ReadingEntity Reading { get; set; }
    }
}
