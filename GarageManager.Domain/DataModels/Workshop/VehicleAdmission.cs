using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.Domain.DataModels
{
    public class VehicleAdmission : AuditableBaseDataModel
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

        public virtual Vehicle Vehicle { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<AdmissionCheckListItem> CheckListItems { get; set; }

        public virtual ICollection<AdmissionRequest> AdmissionRequests { get; set; }

        public virtual ICollection<AdmissionService> AdmissionServices { get; set; }
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
