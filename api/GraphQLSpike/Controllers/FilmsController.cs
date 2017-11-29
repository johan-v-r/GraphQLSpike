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
    public async Task Get()
    {
      var schema = Schema.For(@"
        type Film {
          film_id: Int
          title: String
          description: String
        }

        type Query {
          film(film_id: Int): Film
        }
      ", conf =>
      {
        conf.Types.Include<Query>();
      });

      var result = schema.Execute(conf =>
      {
        conf.Query = "{ film(film_id: 133) { film_id title } }";
      });

      Console.WriteLine(result);
    }
  }
}