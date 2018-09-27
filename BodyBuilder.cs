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

        var bodyBuilder = new StringBuilder();

        bodyBuilder.Append("[");
        for (int i = 0; i < n - 1; ++i)
        {
          bodyBuilder.Append(_configuration["RequestBody"]);
          bodyBuilder.Append(",");
        }
        bodyBuilder.Append(_configuration["RequestBody"]);
        bodyBuilder.Append("]");

        return bodyBuilder.ToString();
      }
    }
  }
}
