using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SDTable.Models;
using SDTable.Services;

namespace SDTable.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class SiteDownsController : ControllerBase
  {
    private readonly SiteDownsService _service;
    public SiteDownsController(SiteDownsService service)
    {
      _service = service;
    }

    [HttpGet]
    public ActionResult<IEnumerable<SiteDown>> GetAll()
    {
      try
      {
        return Ok(_service.GetAll());
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<SiteDown>> PostSiteDown([FromBody] SiteDown newSD)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newSD.CreatorId = userInfo.Id;
        SiteDown created = _service.PostSiteDown(newSD);
        return Ok(created);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{sd_id}")]
    [Authorize]
    public async Task<ActionResult<SiteDown>> EditSD(int sd_id, [FromBody] SiteDown editedSD)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        editedSD.Id = sd_id;

        return Ok(_service.EditSD(editedSD, userInfo.Id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{sd_id}")]
    public async Task<ActionResult<string>> DeleteSD(int sd_id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_service.DeleteSD(sd_id, userInfo.Id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}