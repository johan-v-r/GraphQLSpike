//using GraphQL.Conventions;
//using GraphQL.Conventions.Relay;
using GraphQL;
using GraphQLSpike.Films;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLSpike
{
  public class Query
  {
    [GraphQLMetadata("films")]
    public async Task<List<Film>> GetFilms()
    {
      var filmRepo = new FilmsRepo();
      return (await filmRepo.GetFilmsAsync()).ToList();
    }

    [GraphQLMetadata("film")]
    public async Task<Film> GetFilm(int film_id)
    {
      var filmRepo = new FilmsRepo();
      return await filmRepo.GetFilmAsync(film_id);
    }
  }
}
