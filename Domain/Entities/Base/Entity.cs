using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Base
{
	public class Entity<T> : DomainEntity, IEntity<T>
	{
		[Key] public T Id { get; set; } = default!;
		public bool Status { get; set; }
		[StringLength(35)] [Required] public string CreatedBy { get; set; } = default!;
		[StringLength(35)] public string UpdatedBy { get; set; } = default!;
		public DateTime CreatedOn { get; set; }
		public DateTime? LastModifiedOn { get; set; }
	}
}