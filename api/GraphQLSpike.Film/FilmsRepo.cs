using Dapper;
using Npgsql;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLSpike.Films
{
  public class FilmsRepo
  {
    private const string _connString = "Host=192.168.42.11;Database=dvdrental;Username=postgres;Password=ubu.1900";

    public async Task<IEnumerable<Film>> GetFilmsAsync()
    {
      using (var connection = new NpgsqlConnection(_connString))
      {
        await connection.OpenAsync();

        var result = await connection.QueryAsync<Film>("select * from film");

        return result;
      }
    }

    public async Task<Film> GetFilmAsync(int id)
    {
      var parms = new { film_id = id };

      using (var connection = new NpgsqlConnection(_connString))
      {
        await connection.OpenAsync();

        var result = await connection.QueryAsync<Film>("select * from film where film_id = @film_id", parms);

        return result.FirstOrDefault();
      }
    }
  }
}