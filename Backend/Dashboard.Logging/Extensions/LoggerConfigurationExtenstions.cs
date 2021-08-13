using Dashboard.Infra;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

namespace Dashboard.Logging;

public static partial class LoggerConfigurationExtenstions
{

    public static LoggerConfiguration ConfigureBaseLogging(this LoggerConfiguration loggerConfiguration, string appName, BuildInfo buildInfo)
    {
        if (loggerConfiguration == null)
            throw new ArgumentNullException(nameof(loggerConfiguration));
        if (appName == null)
            throw new ArgumentNullException(nameof(appName));
        if (buildInfo == null)
            throw new ArgumentNullException(nameof(buildInfo));

        loggerConfiguration
            .MinimumLevel.Verbose()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .WriteTo.Console(theme: AnsiConsoleTheme.Code)
            .Enrich.FromLogContext()
            .Enrich.WithMachineName()
            .Enrich.WithThreadId()
            // Build information as custom properties
            .Enrich.WithProperty(nameof(buildInfo.BuildId), buildInfo.BuildId)
            .Enrich.WithProperty(nameof(buildInfo.BuildNumber), buildInfo.BuildNumber)
            .Enrich.WithProperty(nameof(buildInfo.BranchName), buildInfo.BranchName)
            .Enrich.WithProperty(nameof(buildInfo.CommitHash), buildInfo.CommitHash)
            .Enrich.WithProperty("ApplicationName", appName);

        return loggerConfiguration;
    }
}

