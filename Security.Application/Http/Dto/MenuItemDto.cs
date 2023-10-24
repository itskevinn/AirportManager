namespace Security.Application.Http.Dto;

public class MenuItemDto
{
	public Guid Id { get; set; }
	public string Icon { get; set; } = default!;
	public string Label { get; set; } = default!;
	public int Order { get; set; }
	public string RouterLink { get; set; } = default!;
}