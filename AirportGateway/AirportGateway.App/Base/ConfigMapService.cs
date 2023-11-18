using AirportGateway.App.Core.Interface;
using Microsoft.Extensions.Configuration;

namespace AirportGateway.App.Base;

public class ConfigMapService : ISingletonService
{
    public static IConfigurationRoot GetConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath("/app/config")
            .AddJsonFile("airport-gateway-config-map.json");
        return builder.Build();
    }
}