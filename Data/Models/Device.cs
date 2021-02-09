using Smooth.Power.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smooth.Power.Data.Models
{
    public class Device
    {
        public static explicit operator Device(DeviceEntity de)
        {
            return new Device
            {
                SerialNumber = de.SerialNumber,
                LastKnownStatus = de.LastKnownStatus,
                Address1 = de.Address1,
                Address2 = de.Address2,
                Address3 = de.Address3,
                Address4 = de.Address4,
                Readings = de.Readings?.Select(r => (Reading)r).ToList()
            };
        }
        public string SerialNumber { get; set; }
        public SystemStates LastKnownStatus { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string Site { get; set; }
        public List<Reading> Readings { get; set; }
    }
}
