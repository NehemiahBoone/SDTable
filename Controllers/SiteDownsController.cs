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
  }
}