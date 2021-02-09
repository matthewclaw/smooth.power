using System;
using System.Collections.Generic;
using System.Text;

namespace Smooth.Power.Data.Entities
{
   public class ErrorEntity : BaseEntity
    {
        public string Data { get; set; }
        public virtual ReadingEntity Reading { get; set; }
    }
}
