using System;
using System.Collections.Generic;
using System.Text;

namespace GarageManager.Domain.Entities
{
    public abstract class AuditableBaseEntity
    {
        public virtual Guid Id { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
