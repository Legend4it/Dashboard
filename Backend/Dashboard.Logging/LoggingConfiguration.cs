using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Logging
{
    public static class LoggingConfiguration
    {
        public static void GetLogger()
        {
            Log.Logger = new LoggerConfiguration()
            //.MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateLogger();
        }
    }
}
