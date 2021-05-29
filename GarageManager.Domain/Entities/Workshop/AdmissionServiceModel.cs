using System;

namespace GarageManager.Domain.Entities
{
    public class AdmissionServiceModel : AuditableBaseEntity
    {
        public Guid AdmissionId { get; set; }

        public Guid HandledBy { get; set; }

        public Guid? AdmissionRequestId { get; set; }

        public string Description { get; set; }

        public VehicleAdmissionModel VehicleAdmission { get; set; }
    }
}
