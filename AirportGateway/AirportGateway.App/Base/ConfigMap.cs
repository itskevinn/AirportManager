using Microsoft.Extensions.Configuration;

namespace AirportGateway.App.Base;

public static class ConfigMap
{
    public static IConfigurationRoot GetConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath("/app/config")
            .AddJsonFile("airport-gateway-config-map.json");
        return builder.Build();
    }
}