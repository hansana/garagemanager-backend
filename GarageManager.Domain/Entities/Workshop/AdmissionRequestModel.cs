using System;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.Domain.Entities
{
    public class AdmissionRequestModel : AuditableBaseEntity
    {
        [Required]
        public Guid AdmissionId { get; set; }

        public string Description { get; set; }

        public VehicleAdmissionModel VehicleAdmission { get; set; }
    }
}
