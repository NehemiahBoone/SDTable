using System.Data;

namespace SDTable.Repositories
{
  public class SiteDownsRepository
  {
    private readonly IDbConnection _db;
    public SiteDownsRepository(IDbConnection db)
    {
      _db = db;
    }


  }
}