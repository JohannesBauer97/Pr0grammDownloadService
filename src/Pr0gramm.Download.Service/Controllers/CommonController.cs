using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pr0gramm.Download.Service.Abstraction;
using Pr0gramm.Download.Service.Repositorys.Abstraction;

namespace Pr0gramm.Download.Service.Controllers
{
  [Route("api/1/[controller]")]
  [ApiController]
  public class CommonController : ControllerBase
  {
    private readonly ICommonRepository _commonRepository;
    private readonly IRateLimiter _rateLimiter;

    public CommonController(ICommonRepository commonRepository, IRateLimiter rateLimiter)
    {
      _commonRepository = commonRepository;
      _rateLimiter = rateLimiter;
    }

    /// <summary>
    ///   Returns direct media link
    /// </summary>
    /// <param name="url">Link of pr0gramm post e.g. https://pr0gramm.com/top/!%20s%3A800%20-%22video%22%20-fsdghf/3768117 </param>
    /// <param name="redirectToFile">Redirects to direct link</param>
    /// <returns></returns>
    [HttpGet]
    [Route("medialink")]
    public async Task<ActionResult<Uri>> GetDirectMediaLink([FromQuery] string url,
      [FromQuery] bool redirectToFile = true)
    {
      if (string.IsNullOrWhiteSpace(url)) return BadRequest();

      Uri uri;
      try
      {
        uri = new Uri(url);
        if (!uri.Host.Contains("pr0gramm.com")) return BadRequest("URL host is not pr0gramm.com");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }

      if (!_rateLimiter.CheckRateLimit()) return StatusCode((int) HttpStatusCode.TooManyRequests);

      try
      {
        var result = await _commonRepository.GetDirectMediaLink(uri);
        if (redirectToFile) return Redirect(result.ToString());
        return Ok(result);
      }
      catch (Exception e)
      {
        return Problem(e.Message);
      }
    }

    /// <summary>
    ///   Returns the direct media link based on a post id
    /// </summary>
    /// <param name="postId">pr0gramm post id</param>
    /// <returns></returns>
    [HttpGet]
    [Route("medialink/{postId}")]
    public async Task<ActionResult<Uri>> GetDirectMediaLinkByIdAsync(int postId, [FromQuery] bool redirectToFile = true)
    {
      if (!ModelState.IsValid) return BadRequest();

      if (!_rateLimiter.CheckRateLimit()) return StatusCode((int) HttpStatusCode.TooManyRequests);

      try
      {
        var result = await _commonRepository.GetDirectMediaLink(postId);
        if (redirectToFile) return Redirect(result.ToString());
        return Ok(result);
      }
      catch (Exception e)
      {
        return Problem(e.Message);
      }
    }
  }
}