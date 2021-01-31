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
      return _repo.GetAll();
    }

    internal SiteDown GetById(int sd_id)
    {
      var data = _repo.GetById(sd_id);
      if (data == null)
      {
        throw new Exception("Invalid sitedown id");
      }

      return data;
    }

    internal SiteDown PostSD(SiteDown newSD)
    {
      newSD.Id = _repo.PostSD(newSD);
      return newSD;
    }
    internal SiteDown EditSD(SiteDown editedSD, string id)
    {
      SiteDown original = _repo.GetById(editedKeep.Id);
      if (original == null)
      {
        throw new Exception("Invalid Id... from keepsService");
      }

      if (original.CreatorId != userId)
      {
        throw new Exception("NOT AUTHORIZED... from keepsService");
      }
    }

    internal object DeleteSD(int sd_id, string id)
    {
      throw new NotImplementedException();
    }
  }
}