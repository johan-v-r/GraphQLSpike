using GraphQLSpike.Films;
using System;
using System.Threading.Tasks;
using Xunit;

namespace GraphQLSpike.Tests
{
  public class FilmTests
  {
    [Fact]
    public async Task GetFilmsAsyncTest()
    {
      var repo = new FilmsRepo();
      var result = await repo.GetFilmsAsync();

      Assert.NotEmpty(result);
    }

    [Fact]
    public async Task GetFilmAsyncTest()
    {
      var filmId = 133;
      var repo = new FilmsRepo();
      var result = await repo.GetFilmAsync(filmId);

      Assert.Equal(filmId, result.film_id);
    }
  }
}
