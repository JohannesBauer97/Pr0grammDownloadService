using System;
using System.Threading.Tasks;

namespace Pr0gramm.Download.Service.Repositorys.Abstraction
{
  public interface ICommonRepository
  {
    /// <summary>
    ///   Returns the direct media link of a post url
    /// </summary>
    /// <param name="postUri"></param>
    /// <returns></returns>
    public Task<Uri> GetDirectMediaLink(Uri postUri);

    /// <summary>
    ///   Returns the direct media link of a post url
    /// </summary>
    /// <param name="postId"></param>
    /// <returns></returns>
    public Task<Uri> GetDirectMediaLink(int postId);
  }
}