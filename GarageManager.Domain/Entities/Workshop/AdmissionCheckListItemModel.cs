using System;

namespace GarageManager.Domain.Entities
{
    public class AdmissionCheckListItemModel : AuditableBaseEntity
    {
        public Guid AdmissionId { get; set; }

        public Guid CheckListId { get; set; }

        public ItemStatus ItemStatus { get; set; }

        public string Description { get; set; }

        public VehicleAdmissionModel VehicleAdmission { get; set; }

        public VehicleCheckListItemModel CheckListItem { get; set; }
    }

    public enum ItemStatus
    {
        Poor,
        Fair,
        Good
    }
}
