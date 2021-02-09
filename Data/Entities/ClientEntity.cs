using System;
using System.Collections.Generic;
using System.Text;

namespace Smooth.Power.Data.Entities
{
    public class ClientEntity:BaseEntity
    {
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string ContactEmail { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public virtual ICollection<UserEntity> Users { get; set; }
        public virtual ICollection<DeviceEntity> Devices { get; set; }
    }
}
