using Domain.Entities.Base;

namespace Domain.Entities
{
    public class Airline : Entity<Guid>
    {
        public string Name { get; set; } = default!;
    }
}