using Smooth.Power.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smooth.Power.Data.Models
{
    public class Client
    {
        public static explicit operator Client(ClientEntity clientEntity)
        {
            return new Client
            {
                Name = clientEntity.Name,
                ContactNumber = clientEntity.ContactNumber,
                ContactEmail = clientEntity.ContactEmail,
                Address1 = clientEntity.Address1,
                Address2 = clientEntity.Address2,
                Address3 = clientEntity.Address3,
                Address4 = clientEntity.Address4,
                Devices = clientEntity.Devices.Select(d => (Device)d).ToList()
            };
        }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string ContactEmail { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public List<Device> Devices { get; set; }
    }
}
