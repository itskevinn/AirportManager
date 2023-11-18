using System.Text;
using AirportGateway.App.Core.Interface;
using Microsoft.Extensions.Configuration;

namespace Security.Infrastructure.Utils;

public abstract class SecretsService : ISingletonService
{
    private static IConfigurationRoot GetSecrets()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath("/etc/airport-secrets")
            .AddJsonFile("airport-secrets.json");
        return builder.Build();
    }

    public static string GetValue(string key)
    {
        var base64EncodedValue = GetSecrets()[key];
        var originalValueBytes = Convert.FromBase64String(base64EncodedValue);
        var originalValue = Encoding.UTF8.GetString(originalValueBytes);
        return originalValue;
    }
}