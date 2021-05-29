using System;

namespace GarageManager.Domain.Entities
{
    public class CustomerVehicleModel : AuditableBaseEntity
    {
        public Guid VehicleId { get; set; }

        public Guid CustomerId { get; set; }

        public OwnerStatus OwnerStatus { get; set; }

        public CustomerModel Customer { get; set; }

        public VehicleModel Vehicle { get; set; }
    }

    public enum OwnerStatus
    {
        Owned,
        ForSale,
        Sold
    }
}
