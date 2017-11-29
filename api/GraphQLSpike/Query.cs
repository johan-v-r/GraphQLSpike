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
    public async Task<IEnumerable<Film>> GetFilms()
    {
      var filmRepo = new FilmsRepo();
      return await filmRepo.GetFilmsAsync();
    }

    [GraphQLMetadata("film")]
    public async Task<Film> GetFilm(int film_id)
    {
      var filmRepo = new FilmsRepo();
      return await filmRepo.GetFilmAsync(film_id);
    }
  }

  // https://github.com/graphql-dotnet/conventions
  //[ImplementViewer(OperationType.Query)]
  //public class Query
  //{
  //  [Description("Retrieve book by its globally unique ID.")]
  //  public Task<Book> Book(UserContext context, Id id) =>
  //      context.Get<Book>(id);

  //  [Description("Retrieve author by his/her globally unique ID.")]
  //  public Task<Author> Author(UserContext context, Id id) =>
  //      context.Get<Author>(id);

  //  [Description("Search for books and authors.")]
  //  public Connection<SearchResult> Search(
  //      UserContext context,
  //      [Description("Title or last name.")] NonNull<string> forString,
  //      [Description("Only return search results after given cursor.")] Cursor? after,
  //      [Description("Return the first N results.")] int? first)
  //  {
  //    return context
  //        .Search(forString.Value)
  //        .Select(node => new SearchResult { Instance = node })
  //        .ToConnection(first ?? 5, after);
  //  }
  //}

  //public class Book
  //{
  //  public int id { get; set; }
  //}

  //public class Author
  //{

  //}
}
