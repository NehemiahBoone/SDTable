using System;
using System.Collections.Generic;
using SDTable.Models;
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

    internal IEnumerable<SiteDown> GetAll()
    {
      throw new NotImplementedException();
    }

    internal SiteDown PostSD(SiteDown newSD)
    {
      throw new NotImplementedException();
    }
    internal SiteDown EditSD(SiteDown editedSD, string id)
    {
      throw new NotImplementedException();
    }
    internal object DeleteSD(int sd_id, string id)
    {
      throw new NotImplementedException();
    }
  }
}