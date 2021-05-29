using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.Domain.DataModels
{
    public class AdmissionCheckListItem : AuditableBaseDataModel
    {
        public Guid AdmissionId { get; set; }

        public Guid CheckListId { get; set; }

        public ItemStatus ItemStatus { get; set; }

        public string Description { get; set; }

        public virtual VehicleAdmission VehicleAdmission { get; set; }

        public virtual VehicleCheckListItem CheckListItem { get; set; }
    }

    public enum ItemStatus
    {
        Poor,
        Fair,
        Good
    }
}
