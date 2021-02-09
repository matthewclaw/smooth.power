using Smooth.Power.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smooth.Power.Data.Models
{
    public class Phase
    {
        public static explicit operator Phase (PhaseEntity pe)
        {
            return new Phase
            {
                Voltage = pe.Voltage,
                Current = pe.Current,
                PFCurrently = pe.PFCurrently,
                PFCorrectedFor = pe.PFCorrectedFor,
                PowerUsage = pe.PowerUsage,
                VAHSavedThisMonthToDate = pe.VAHSavedThisMonthToDate,
                VAHUsedThisMonthToDate = pe.VAHUsedThisMonthToDate
            };
        }
        public double Voltage { get; set; }
        public double Current { get; set; }
        public double PFCurrently { get; set; }
        public double PFCorrectedFor { get; set; }
        public double PowerUsage { get; set; }
        public double VAHUsedThisMonthToDate { get; set; }
        public double VAHSavedThisMonthToDate { get; set; }
    }
}
