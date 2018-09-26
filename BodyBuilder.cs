using System.Text;
using Microsoft.Extensions.Configuration;

namespace HttpBenchmarkService
{
  public class BodyBuilder
  {
    private readonly IConfigurationSection _configuration;

    public BodyBuilder(IConfigurationSection configuration)
    {
      _configuration = configuration;
    }

    public string Body
    {
      get
      {
        int.TryParse(_configuration["N"], out int n);

        var logsBuilder = new StringBuilder();

        logsBuilder.Append("[");
        for (int i = 0; i < n - 1; ++i)
        {
          logsBuilder.Append(_configuration["RequestBody"]);
          logsBuilder.Append(",");
        }
        logsBuilder.Append($"{_configuration["RequestBody"]}");
        logsBuilder.Append("]");

        return logsBuilder.ToString();
      }
    }
  }
}
