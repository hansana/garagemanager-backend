using GarageManager.Domain.Common;
using GarageManager.Domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.Domain.Entities
{
    public class VehicleModel : AuditableBaseEntity
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

        public List<CustomerVehicleModel> CustomerVehicles { get; set; }
    }
}
