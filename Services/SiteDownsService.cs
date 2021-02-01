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
    internal SiteDown EditSD(SiteDown editedSD, string userId)
    {
      SiteDown original = _repo.GetById(editedSD.Id);
      if (original == null)
      {
        throw new Exception("Invalid sitedown id");
      }

      if (original.CreatorId != userId)
      {
        throw new Exception("NOT AUTHORIZED");
      }

      editedSD.SiteNum = editedSD.SiteNum == null ? original.SiteNum : editedSD.SiteNum;
      editedSD.SiteName = editedSD.SiteName == null ? original.SiteName : editedSD.SiteName;
      editedSD.Cause = editedSD.Cause == null ? original.Cause : editedSD.Cause;
      editedSD.Solved = editedSD.Solved;
      editedSD.Creator = editedSD.Creator == null ? original.Creator : editedSD.Creator;
      editedSD.CreatorId = editedSD.CreatorId == null ? original.CreatorId : editedSD.CreatorId;

      return _repo.EditSD(editedSD);
    }

    internal object DeleteSD(int sd_id, string userId)
    {
      SiteDown original = _repo.GetById(sd_id);
      if (original == null)
      {
        throw new Exception("Invalid sitedown id");
      }

      if (original.CreatorId != userId)
      {
        throw new Exception("NOT AUTHORIZED");
      }

      _repo.DeleteSD(sd_id);
      return "Successfully Deleted";
    }
  }
}