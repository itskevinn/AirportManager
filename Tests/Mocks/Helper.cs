using System;
using Infrastructure.Core.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace Tests.Mocks;

public static class Helper
{
    private static IServiceProvider Provider()
    {
        var services = new ServiceCollection();
        services.AddScoped<AppSettings>();
        return services.BuildServiceProvider();
    }

    public static AppSettings? GetAppSettings()
    {
        var provider = Provider();
        return provider.GetService<AppSettings>();
    }
    
}