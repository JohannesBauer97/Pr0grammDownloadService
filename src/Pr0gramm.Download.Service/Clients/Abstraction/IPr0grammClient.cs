using System.Threading.Tasks;
using Pr0gramm.Download.Service.Models;

namespace Pr0gramm.Download.Service.Clients.Abstraction
{
  public interface IPr0grammClient
  {
    /// <summary>
    ///   Returns Post Item with specific id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<Item> GetItemById(int id);
  }
}