using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace HttpBenchmarkService
{
  public abstract class HttpService : IHostedService
  {
    protected readonly IConfiguration Configuration;
    protected readonly IHttpClientFactory HttpClientFactory;

    protected HttpService(IConfiguration configuration,
      IHttpClientFactory httpClientFactory)
    {
      Configuration = configuration;
      HttpClientFactory = httpClientFactory;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
      await Console.Out.WriteLineAsync($"Starting {GetType().Name}...");

      await InitializeAsync();

      await Console.Out.WriteLineAsync($"{GetType().Name} started.");
    }

    public Task StopAsync(CancellationToken cancellationToken)
      => Console.Out.WriteLineAsync($"{GetType().Name} stopped.");

    protected abstract Task InitializeAsync();
  }
}
