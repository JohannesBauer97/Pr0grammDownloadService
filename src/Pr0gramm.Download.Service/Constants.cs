using System;
using System.Text.RegularExpressions;

namespace Pr0gramm.Download.Service
{
  public static class Constants
  {
    public static int Version = 1;
    public static string ItemGetUrl = "https://pr0gramm.com/api/items/get?id={0}";
    public static Uri VideoBaseUrl = new Uri("https://vid.pr0gramm.com/");
    public static Uri ImageBaseUrl = new Uri("https://img.pr0gramm.com/");
    public static Uri FullsizeBaseUrl = new Uri("https://full.pr0gramm.com/");
    public static Regex VideoRegex = new Regex("/\\.mp4$/");
  }
}