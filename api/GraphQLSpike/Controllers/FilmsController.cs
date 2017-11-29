using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GraphQLSpike.Controllers
{
  [Produces("application/json")]
  [Route("api/Films")]
  public class FilmsController : Controller
  {
    public async Task<ActionResult> Get()
    {
      throw new NotImplementedException();
    }
  }
}