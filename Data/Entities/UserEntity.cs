using System;
using System.Collections.Generic;
using System.Text;

namespace Smooth.Power.Data.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsClientAdmin { get; set; }
        public virtual ClientEntity Client { get; set; }
    }
}
