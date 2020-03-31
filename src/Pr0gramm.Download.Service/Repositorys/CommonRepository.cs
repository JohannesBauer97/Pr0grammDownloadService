using System;
using System.Threading.Tasks;
using Pr0gramm.Download.Service.Clients.Abstraction;
using Pr0gramm.Download.Service.Repositorys.Abstraction;

namespace Pr0gramm.Download.Service.Repositorys
{
  public class CommonRepository : ICommonRepository
  {
    private readonly IPr0grammClient _pr0GrammClient;

    public CommonRepository(IPr0grammClient pr0grammClient)
    {
      _pr0GrammClient = pr0grammClient;
    }

    /// <inheritdoc />
    public async Task<Uri> GetDirectMediaLink(Uri postUri)
    {
      var postId = (int) GetIdFromPostUrl(postUri);
      return await GetDirectMediaLink(postId);
    }

    /// <inheritdoc />
    public async Task<Uri> GetDirectMediaLink(int postId)
    {
      var item = await _pr0GrammClient.GetItemById(postId);
      if (Constants.VideoRegex.IsMatch(item.Image))
        return new Uri(Constants.VideoBaseUrl, new Uri(item.Image, UriKind.Relative));
      if (string.IsNullOrWhiteSpace(item.Fullsize))
        return new Uri(Constants.ImageBaseUrl, new Uri(item.Image, UriKind.Relative));
      return new Uri(Constants.FullsizeBaseUrl, new Uri(item.Fullsize, UriKind.Relative));
    }

    /// <summary>
    ///   Returns the post id of the given pr0gramm post url.
    ///   Throws exception if url does not contain an id
    /// </summary>
    /// <param name="postUri"></param>
    /// <returns></returns>
    private long GetIdFromPostUrl(Uri postUri)
    {
      long result = 0;
      foreach (var postUriSegment in postUri.Segments)
        if (long.TryParse(postUriSegment, out result))
          break;

      if (result <= 0) throw new Exception($"Unable to find id in post url {postUri}");
      return result;
    }
  }
}