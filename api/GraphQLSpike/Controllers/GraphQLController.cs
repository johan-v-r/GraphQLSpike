using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GraphQL.Types;
using GraphQL;

namespace GraphQLSpike.Controllers
{
  [Produces("application/json")]
  [Route("api/GraphQL")]
  public class GraphQLController : Controller
  {
    private readonly ISchema _schema;

    public GraphQLController(ISchema schema)
    {
      _schema = schema;
    }

    public async Task<ActionResult> Get(string query)
    {
      var result = _schema.Execute(conf =>
      {
        //conf.Query = "{ film(film_id: 133) { film_id title } }";
        //conf.Query = "{ films { film_id title } }";
        conf.Query = query;
      });

      Console.WriteLine(result);

      return Ok(result);
    }
  }
}