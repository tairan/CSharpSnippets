using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateGenericHostBuilder(args).Build().Start();
        }

        private static IHostBuilder CreateGenericHostBuilder(string[] args) => new HostBuilder()
            .ConfigureHostConfiguration((context) =>
            {
                context.SetBasePath(Directory.GetCurrentDirectory());
                context.AddJsonFile("hostsettings.json", optional: true);
                context.AddEnvironmentVariables(prefix: "PREFIX_");
                context.AddCommandLine(args);
            })
            .ConfigureAppConfiguration((context, config) =>
            {
                config.AddJsonFile("appsettings.json", optional: true);
                config.AddEnvironmentVariables(prefix: "PREFIX_");
                config.AddCommandLine(args);
            })
            .ConfigureServices((context, services) =>
            {

            })
            .ConfigureLogging((context, logging) =>
            {
                logging.AddConsole();
                logging.AddDebug();
            })
            .UseConsoleLifetime();
            }
}
