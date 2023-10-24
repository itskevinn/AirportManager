using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Security.Domain.Entity.Base;

namespace Security.Domain.Entity;

public class Role : AuditableEntity<Guid>
{
    public string RoleName { get; set; } = default!;
    [NotMapped] [JsonIgnore] public IEnumerable<MenuItem> Authorities { get; set; } = default!;
    public IEnumerable<UserRole> UserRoles { get; set; } = default!;
    public IEnumerable<MenuItemRole> RoleMenuItems { get; set; } = default!;
}