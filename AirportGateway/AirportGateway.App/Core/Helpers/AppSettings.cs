namespace AirportGateway.App.Core.Helpers;

public class AppSettings
{
    public AppSettings()
    {
        MicroservicesUrls = new MicroservicesUrls();
    }

    public string Secret { get; set; } = default!;
    public MicroservicesUrls MicroservicesUrls { get; set; }
}

public class MicroservicesUrls
{
    public string SecurityUrl { get; set; } = default!;
    public string FlightsManagementUrl { get; set; } = default!;
}