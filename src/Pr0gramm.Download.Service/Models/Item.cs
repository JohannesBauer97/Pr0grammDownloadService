namespace Pr0gramm.Download.Service.Models
{
  public class Item
  {
    public int Id { get; set; }
    public int Promoted { get; set; }
    public int UserId { get; set; }
    public int Up { get; set; }
    public int Down { get; set; }
    public int Created { get; set; }
    public string Image { get; set; }
    public string Thumb { get; set; }
    public string Fullsize { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public bool Audio { get; set; }
    public string Source { get; set; }
    public int Flags { get; set; }
    public string User { get; set; }
    public int Mark { get; set; }
    public int Gift { get; set; }
  }
}