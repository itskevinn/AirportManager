namespace Security.Infrastructure.Core.Helpers;

public class AppSettings
{
    public string SchemaName { get; set; } = default!;
    public string Secret { get; set; } = default!;
    public string FileSize { get; set; } = default!;
    public string AttachmentsFolderName { get; set; } = default!;
    public Aws Aws { get; set; } = default!;
}

public class Aws
{
    public string Profile { get; set; } = default!;
    public string Region { get; set; } = default!;
    public string ServiceUrl { get; set; } = default!;
}