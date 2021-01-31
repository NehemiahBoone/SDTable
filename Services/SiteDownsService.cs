using SDTable.Repositories;

namespace SDTable.Services
{
  public class SiteDownsService
  {
    private readonly SiteDownsRepository _repo;
    public SiteDownsService(SiteDownsRepository repo)
    {
      _repo = repo;
    }
  }
}