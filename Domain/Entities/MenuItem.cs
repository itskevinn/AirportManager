namespace Domain.Entities;

public class MenuItem
{
    public string IconClass { get; set; }
    public string Route { get; set; }
    public string Title { get; set; }
    public IEnumerable<MenuItemRole> MenuItemRoles { get; set; }
}