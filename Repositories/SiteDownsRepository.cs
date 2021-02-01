using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using SDTable.Models;

namespace SDTable.Repositories
{
  public class SiteDownsRepository
  {
    private readonly IDbConnection _db;
    private readonly string populateCreator = @"
    SELECT
    sitedown.*,
    profile.*
    FROM sitedowns sitedown
    JOIN profiles profile on sitedown.creatorId = profile.Id ";
    public SiteDownsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<SiteDown> GetAll()
    {
      string sql = populateCreator;
      return _db.Query<SiteDown, Profile, SiteDown>(sql, (sitedown, profile) => { sitedown.Creator = profile; return sitedown; }, splitOn: "id");
    }

    internal SiteDown GetById(int sd_id)
    {
      string sql = populateCreator + "WHERE sitedown.id = @sd_id";
      return _db.Query<SiteDown, Profile, SiteDown>(sql, (sitedown, profile) => { sitedown.Creator = profile; return sitedown; }, new { sd_id }, splitOn: "id").FirstOrDefault();
    }

    internal int PostSD(SiteDown newSD)
    {
      string sql = @"
      INSERT INTO sitedowns
      (creatorId, siteNum, siteName, cause, solved)
      VALUES
      (@CreatorId, @SiteNum, @SiteName, @Cause, @Solved);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newSD);
    }

    internal SiteDown EditSD(SiteDown editedSD)
    {
      string sql = @"
      UPDATE sitedowns
      SET
      creatorId = @CreatorId,
      siteNum = @SiteNum,
      siteName = @SiteName,
      cause = @Cause,
      solved = @Solved
      WHERE id = @Id;";
      _db.Execute(sql, editedSD);
      return editedSD;
    }

    internal void DeleteSD(int id)
    {
      string sql = "DELETE FROM sitedowns where id = @id";
      _db.Execute(sql, new { id });
    }
  }
}