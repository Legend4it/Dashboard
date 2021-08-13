using Dashboard.Infra;
using Serilog;

namespace Dashboard.Logging
{
    public static class Logger
    {
        public static void SetupSerilogLogger(string appName, BuildInfo buildInfo)
        {
            Log.Logger = new LoggerConfiguration()
                .ConfigureBaseLogging(appName, buildInfo)
                .CreateBootstrapLogger();
        }
    }
}
