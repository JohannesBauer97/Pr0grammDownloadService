using System;

namespace Pr0gramm.Download.Service.Models
{
  public class RateLimit
  {
    public DateTime LastChange { get; set; } = DateTime.Now;
    public int Hitcounter { get; set; } = 0;
  }
}