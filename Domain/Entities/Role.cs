using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Domain.Constants.Enum;
using Domain.Entities.Base;

namespace Domain.Entities;

public class Role : Entity<Guid>
{
    public RoleNameEnum RoleName { get; set; }
    [NotMapped] [JsonIgnore] public IEnumerable<MenuItem> Authorities { get; set; } = default!;
    public IEnumerable<UserRole> UserRoles { get; set; } = default!;
    public IEnumerable<MenuItemRole> RoleMenuItems { get; set; }
}