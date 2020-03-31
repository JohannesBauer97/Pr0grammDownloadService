using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Pr0gramm.Download.Service.Clients.Abstraction;
using Pr0gramm.Download.Service.Models;

namespace Pr0gramm.Download.Service.Clients
{
  public class Pr0grammClient : IPr0grammClient
  {
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<Pr0grammClient> _logger;

    public Pr0grammClient(IHttpClientFactory httpClientFactory, ILogger<Pr0grammClient> logger)
    {
      _httpClientFactory = httpClientFactory;
      _logger = logger;
    }

    /// <inheritdoc />
    public async Task<Item> GetItemById(int id)
    {
      using (var client = _httpClientFactory.CreateClient())
      {
        var uri = new Uri(Constants.ItemGetUrl.Replace("{0}", id.ToString()));
        var response = await client.GetAsync(uri);
        if (!response.IsSuccessStatusCode)
        {
          _logger.LogError("Requesting {0} ended in {1}", uri, response.StatusCode);
          throw new Exception("Request to pr0gramm failed.");
        }

        try
        {
          var itemResponse =
            JsonConvert.DeserializeObject<ItemResponse>(await response.Content.ReadAsStringAsync());
          return itemResponse.Items.First(x => x.Id == id);
        }
        catch (Exception e)
        {
          _logger.LogError("Error parsing response from {0}:{1}", uri, e.Message);
          _logger.LogDebug("Response content: {0}", await response.Content.ReadAsStringAsync());
          throw new Exception("Can't parse response from pr0gramm");
        }
      }
    }
  }
}