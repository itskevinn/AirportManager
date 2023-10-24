namespace Security.Domain.Entity.Base;

public class BaseEntity<TKey> :  DomainEntity, IBaseEntity<TKey>
{
    public TKey Id { get; set; } = default!;
}