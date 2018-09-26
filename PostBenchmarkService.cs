using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace HttpBenchmarkService
{
  public class PostBenchmarkService : HttpBenchmarkService
  {
    private readonly IConfigurationSection _configuration;

    public PostBenchmarkService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
      : base(configuration, httpClientFactory)
    {
      _configuration = Configuration.GetSection("Services").GetSection("Benchmark");
    }

    protected override async Task InitializeAsync()
    {
      HttpClient client = HttpClientFactory.CreateClient();
      string url = _configuration["RequestUri"];
      StringContent body = new StringContent(
        new BodyBuilder(_configuration).Body, Encoding.UTF8, "application/json");

      long elapsed = await BenchmarkMsAsync(() => client.PostAsync(url, body));
      await Console.Out.WriteLineAsync($"{elapsed}ms");
    }
  }
}
