using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.Domain.DataModels
{
    public class AdmissionRequest : AuditableBaseDataModel
    {
        [Required]
        public Guid AdmissionId { get; set; }

        public string Description { get; set; }

        public virtual VehicleAdmission VehicleAdmission { get; set; }

        public virtual AdmissionService AdmissionService { get; set; }
    }
}
