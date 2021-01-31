using Microsoft.AspNetCore.Mvc;

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
  }
}