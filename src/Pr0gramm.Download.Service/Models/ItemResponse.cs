using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Pr0gramm.Download.Service.Models
{
  public class ItemResponse
  {
    public bool AtEnd { get; set; }
    public bool AtStart { get; set; }
    public JToken Error { get; set; }
    public List<Item> Items { get; set; }
    public int Ts { get; set; }
    public string Cache { get; set; }
    public int Rt { get; set; }
    public int Qc { get; set; }
  }
}