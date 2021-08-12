using Microsoft.Extensions.Configuration;
using Serilog;

namespace Dashboard.Logging;

public static class LoggingConfiguration
{
    public static void GetLogger()
    {
        var configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build();

        Log.Logger = new LoggerConfiguration()
                        .ReadFrom.Configuration(configuration)
                        .CreateLogger();
    }
}
