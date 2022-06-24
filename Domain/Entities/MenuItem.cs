using Domain.Entities.Base;

namespace Domain.Entities;

public class MenuItem : Entity<Guid>
{
	public string Icon { get; set; } = default!;
	public string RouterLink { get; set; } = default!;
	public string Label { get; set; } = default!;
	public int Order { get; set; } = default!;
	public IEnumerable<MenuItemRole> MenuItemRoles { get; set; } = default!;
}