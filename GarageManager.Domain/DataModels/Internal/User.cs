using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.Domain.DataModels
{
    public class User : AuditableBaseDataModel
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [Phone]
        public string MobileNumber { get; set; }

        public string HomeNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        public virtual ICollection<VehicleAdmission> VehicleAdmissions { get; set; }

        public virtual ICollection<AdmissionService> AdmissionServices { get; set; }
    }
}
