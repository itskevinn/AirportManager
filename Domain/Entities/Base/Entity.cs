using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Base
{
    public class Entity<T> : DomainEntity, IEntity<T>
    {
        public T Id { get; set; } = default!;
        public bool Status { get; set; }
        [Required] public string CreatedBy { get; set; } = default!;
        public string UpdatedBy { get; set; } = default!;
        public DateTime CreatedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }
    }
}