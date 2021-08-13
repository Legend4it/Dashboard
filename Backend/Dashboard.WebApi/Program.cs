
using Pastel;
using Serilog;
using System.Drawing;
using Autofac.Extensions.DependencyInjection;
using Dashboard.Logging;
using Dashboard.Infra;

namespace Dashboard.WebApi;

public class Program
{
    public static readonly string AppName = "Dashboard.WebApi" + "Service";

    public static void Main(string[] args)
    {
        SayHello();

        Logger.SetupSerilogLogger(AppName, AppVersionInfo.GetBuildInfo);

        try
        {

            Log.Information("Starting web host '{ApplicationName}'...", AppName);
            CreateHostBuilder(args).Build().Run();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Application start-up failed");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
               Host.CreateDefaultBuilder(args)
                   .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                   .UseSerilog((context, services, configuration) => configuration
                       .ConfigureBaseLogging(AppName, AppVersionInfo.GetBuildInfo)
                       .ReadFrom.Services(services)
                    )
                   .ConfigureWebHostDefaults(webBuilder =>
                   {
                       webBuilder.UseStartup<Startup>();
                       Log.Information("Starting up '{ApplicationName}'...", AppName);
                   });
    internal static void SayHello()
    {
        Console.WriteLine(@"
                ██████╗  █████╗ ███████╗██╗  ██╗██████╗  ██████╗  █████╗ ██████╗ ██████╗ 
                ██╔══██╗██╔══██╗██╔════╝██║  ██║██╔══██╗██╔═══██╗██╔══██╗██╔══██╗██╔══██╗
                ██║  ██║███████║███████╗███████║██████╔╝██║   ██║███████║██████╔╝██║  ██║
                ██║  ██║██╔══██║╚════██║██╔══██║██╔══██╗██║   ██║██╔══██║██╔══██╗██║  ██║
                ██████╔╝██║  ██║███████║██║  ██║██████╔╝╚██████╔╝██║  ██║██║  ██║██████╔╝
                ╚═════╝ ╚═╝  ╚═╝╚══════╝╚═╝  ╚═╝╚═════╝  ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚═════╝ 
            ".Pastel(Color.DarkSeaGreen));

    }

    internal static void BuildConfig(IConfigurationBuilder builder)
    {
        // Check the current directory that the application is running on 
        // Then once the file 'appsetting.json' is found, we are adding it.
        // We add env variables, which can override the configs in appsettings.json
        builder.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();
    }
}
