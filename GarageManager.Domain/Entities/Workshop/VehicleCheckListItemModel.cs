using System;

namespace GarageManager.Domain.Entities
{
    public class VehicleCheckListItemModel : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
