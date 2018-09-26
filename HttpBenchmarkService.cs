using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace HttpBenchmarkService
{
  public abstract class HttpBenchmarkService : HttpService
  {
    protected HttpBenchmarkService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
      : base(configuration, httpClientFactory)
    { }

    protected static async Task<long> BenchmarkMsAsync(Func<Task> benchAction)
    {
      Stopwatch watch = Stopwatch.StartNew();
      await benchAction();
      watch.Stop();

      return watch.ElapsedMilliseconds;
    }
  }
}
