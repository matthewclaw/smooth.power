using System;
using System.Collections.Generic;
using System.Text;

namespace Smooth.Power.Data.Entities
{
    public class ReadingEntity : BaseEntity
    {
        public SystemStates SystemState { get; set; }
        public virtual DeviceEntity Device { get; set; }
        public virtual ICollection<PhaseEntity> Phases { get; set; }
        public virtual ICollection<ErrorEntity> Errors { get; set; }
    }
}
