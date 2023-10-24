namespace Security.Domain.Entity.Base;

public interface IBaseEntity<TKey>

{
    public TKey Id { get; set; }
}