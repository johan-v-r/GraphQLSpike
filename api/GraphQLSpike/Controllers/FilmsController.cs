using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GraphQL.Types;
using GraphQL;

namespace GraphQLSpike.Controllers
{
  [Produces("application/json")]
  [Route("api/Films")]
  public class FilmsController : Controller
  {
    private readonly ISchema _schema;

    public FilmsController(ISchema schema)
    {
      _schema = schema;
    }

    public async Task<ActionResult> Get()
    {
      var result = _schema.Execute(conf =>
      {
        //conf.Query = "{ film(film_id: 133) { film_id title } }";
        conf.Query = "{ films { film_id title } }";
      });

      Console.WriteLine(result);

      return Ok(result);
    }
  }
}