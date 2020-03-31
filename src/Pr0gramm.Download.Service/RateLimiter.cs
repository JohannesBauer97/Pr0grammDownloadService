using System;
using Pr0gramm.Download.Service.Abstraction;
using Pr0gramm.Download.Service.Models;

namespace Pr0gramm.Download.Service
{
  public class RateLimiter : IRateLimiter
  {
    /// <inheritdoc />
    public RateLimit CurrentRate { get; } = new RateLimit();

    /// <inheritdoc />
    public int MaxHits { get; } = 3;

    /// <inheritdoc />
    public int ResetAfterSeconds { get; } = 10;

    /// <inheritdoc />
    public bool CheckRateLimit()
    {
      if (CurrentRate.LastChange > DateTime.Now.Subtract(TimeSpan.FromSeconds(ResetAfterSeconds)))
      {
        if (CurrentRate.Hitcounter >= MaxHits)
          // max: 3 requests in 10s
          return false;
      }
      else if (CurrentRate.LastChange < DateTime.Now.Subtract(TimeSpan.FromSeconds(10)))
      {
        // reset cache
        ResetRateLimit();
      }

      CurrentRate.Hitcounter++;
      return true;
    }

    /// <inheritdoc />
    public void ResetRateLimit()
    {
      CurrentRate.Hitcounter = 0;
      CurrentRate.LastChange = DateTime.Now;
    }
  }
}