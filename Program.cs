using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HttpBenchmarkService
{
  class Program
  {
    public static async Task Main(string[] args)
    {
      var host = new HostBuilder()
        .ConfigureAppConfiguration((hostContext, configApp) =>
        {
          configApp.SetBasePath(Directory.GetCurrentDirectory());

          configApp.AddJsonFile("appsettings.json", optional: true);
          configApp.AddEnvironmentVariables();
          configApp.AddCommandLine(args);
        })
        .ConfigureServices((hostContext, services) =>
        {
          services.AddLogging();
          services.AddHttpClient();
          services.AddHostedService<PostBenchmarkService>();
        })
        .ConfigureLogging((hostContext, configLogging) =>
        {
          // configLogging.AddConsole();
        })
        .UseConsoleLifetime()
        .Build();

      await host.RunAsync();
    }
  }
}
