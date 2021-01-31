namespace SDTable.Models
{
  public class SiteDown
  {
    public int Id { get; set; }
    public string SiteNum { get; set; }
    public string SiteName { get; set; }
    public string Cause { get; set; }
    public bool Solved { get; set}
  }
}