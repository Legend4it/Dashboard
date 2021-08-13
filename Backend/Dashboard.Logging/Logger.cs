using Dashboard.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
