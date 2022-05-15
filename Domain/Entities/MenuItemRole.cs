
using Domain.Entities.Base;

namespace Domain.Entities;

public class MenuItemRole : Entity<Guid>
{
    public Guid MenuItemId { get; set; }
    public MenuItem MenuItem { get; set; } = default!;
    public Guid RoleId { get; set; }
    public Role Role { get; set; } = default!;
}