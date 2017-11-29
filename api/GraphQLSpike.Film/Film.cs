using NpgsqlTypes;
using System.Collections.Generic;

namespace GraphQLSpike.Films
{
  public class Film
  {
    public int film_id { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public int release_year { get; set; }
    public int language_id { get; set; }
    public int rental_duration { get; set; }
    public double rental_rate { get; set; }
    public int length { get; set; }
    public double replacement_cost { get; set; }
    public string rating { get; set; }
    public string last_update { get; set; }
    public string[] special_features { get; set; }
    public NpgsqlTsVector fulltext { get; set; }
  }
}
