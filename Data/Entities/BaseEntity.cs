using System;
using System.Collections.Generic;
using System.Text;

namespace Smooth.Power.Data.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime LastUpdateTime { get; set; }
    }
}
