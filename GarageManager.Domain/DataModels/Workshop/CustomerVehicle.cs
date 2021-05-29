using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.Domain.DataModels
{
    public class CustomerVehicle : AuditableBaseDataModel
    {
        public Guid VehicleId { get; set; }

        public Guid CustomerId { get; set; }

        public OwnerStatus OwnerStatus { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Vehicle Vehicle { get; set; }
    }

    public enum OwnerStatus
    {
        Owned,
        ForSale,
        Sold
    }
}
