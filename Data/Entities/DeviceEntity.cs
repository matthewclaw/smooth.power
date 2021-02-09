using System;
using System.Collections.Generic;
using System.Text;

namespace Smooth.Power.Data.Entities
{
    public class DeviceEntity : BaseEntity
    {
        public string SerialNumber { get; set; }
        public SystemStates LastKnownStatus { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string Site { get; set; }
        public virtual ClientEntity Client { get; set; }
        public virtual ICollection<ReadingEntity> Readings { get; set; }
    }
}
