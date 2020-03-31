using Pr0gramm.Download.Service.Models;

namespace Pr0gramm.Download.Service.Abstraction
{
  public interface IRateLimiter
  {
    /// <summary>
    ///   Returns the current rate info
    /// </summary>
    public RateLimit CurrentRate { get; }

    /// <summary>
    ///   Gets the maximum number of hits
    /// </summary>
    public int MaxHits { get; }

    /// <summary>
    ///   Gets the time when the rate limit will reset
    /// </summary>
    public int ResetAfterSeconds { get; }

    /// <summary>
    ///   Checks if rate limit is reached and increments the hit counter
    /// </summary>
    /// <returns>True if rate limit not reached; False if rate limit reached</returns>
    bool CheckRateLimit();

    /// <summary>
    ///   Resets rate limit counter
    /// </summary>
    void ResetRateLimit();
  }
}