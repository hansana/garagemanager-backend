using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.Domain.DataModels
{
    public class AdmissionService : AuditableBaseDataModel
    {
        public Guid AdmissionId { get; set; }

        public Guid HandledBy { get; set; }

        public Guid? AdmissionRequestId { get; set; }

        public string Description { get; set; }

        public virtual VehicleAdmission VehicleAdmission { get; set; }

        public virtual User User { get; set; }

        public virtual AdmissionRequest AdmissionRequest { get; set; }
    }
}
