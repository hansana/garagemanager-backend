using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.Domain.DataModels
{
    public class VehicleCheckListItem : AuditableBaseDataModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<AdmissionCheckListItem> AdmissionCheckListItems { get; set; }
    }
}
