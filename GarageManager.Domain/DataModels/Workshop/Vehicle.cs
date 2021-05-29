using GarageManager.Domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.Domain.DataModels
{
    public class Vehicle : AuditableBaseDataModel
    {
        [Required]
        public string RegistrationNumber { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }

        public string ChassisNumber { get; set; }

        public string ManufacturedYear { get; set; }

        [Required]
        public VehicleType VehicleType { get; set; }

        [Required]
        public Transmission Transmission { get; set; }

        public DateTime LastCheckedIn { get; set; }

        public virtual ICollection<VehicleAdmission> VehicleAdmissions { get; set; }

        public virtual ICollection<CustomerVehicle> CustomerVehicles { get; set; }
    }
}
