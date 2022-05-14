using Domain.Entities.Base;

namespace Domain.Entities;

public class City : Entity<Guid>
{
    public string Name { get; set; } = default!;
}