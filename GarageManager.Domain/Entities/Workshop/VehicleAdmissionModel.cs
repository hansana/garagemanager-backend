using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.Domain.Entities
{
    public class VehicleAdmissionModel : AuditableBaseEntity
    {
        [Required]
        public Guid VehicleId { get; set; }

        [Required]
        public Guid CustomerId { get; set; }
        
        [Required]
        public int Odometer { get; set; }

        [Required]
        [Range(1, 10)]
        public int FuelLevel { get; set; }

        [Required]
        public Guid HandledBy { get; set; }

        [Required]
        public DateTime AdmissionDate { get; set; }

        public DateTime? ReleasedDate { get; set; }

        [Required]
        public AdmissionStatus Status { get; set; }

        public VehicleModel Vehicle { get; set; }

        public CustomerModel Customer { get; set; }

        public UserModel HandledUser { get; set; }

        public List<AdmissionCheckListItemModel> CheckListItems { get; set; }

        public List<AdmissionRequestModel> AdmissionRequests { get; set; }

        public List<AdmissionServiceModel> AdmissionServices { get; set; }
    }

    public enum AdmissionStatus
    {
        Todo,
        OnGoing,
        Hold,
        Finished,
        Released
    }
}
