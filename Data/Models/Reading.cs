using Smooth.Power.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smooth.Power.Data.Models
{
    public class Reading
    {
        public static explicit operator Reading(ReadingEntity re)
        {
            return new Reading
            {
                SystemState = re.SystemState,
                DeviceSerialNumber = re.Device.SerialNumber,
                Errors = re.Errors?.Select(e => e.Data).ToList(),
                Phases = re.Phases?.Select(p => (Phase)p).ToList()
            };
        }
        public SystemStates SystemState { get; set; }
        public string DeviceSerialNumber { get; set; }
        public List<Phase> Phases { get; set; }
        public List<string> Errors { get; set; }
    }
}
