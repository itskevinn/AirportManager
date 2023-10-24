
using Security.Domain.Entity.Base;

namespace Security.Domain.Entity;

public class MenuItemRole : AuditableEntity<Guid>
{
    public Guid MenuItemId { get; set; }
    public MenuItem MenuItem { get; set; } = default!;
    public Guid RoleId { get; set; }
    public Role Role { get; set; } = default!;
}