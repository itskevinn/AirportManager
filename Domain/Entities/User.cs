using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Domain.Entities.Base;

namespace Domain.Entities;

public class User : Entity<Guid>
{
    public string Name { get; set; } = default!;
    public string Username { get; set; } = default!;

    [JsonIgnore] [Column("pazzword")] public string Password { get; set; } = default!;
    public IEnumerable<UserRole> UserRoles { get; set; } = default!;
    [NotMapped] [JsonIgnore] public IEnumerable<Role> Roles { get; set; } = default!;
}