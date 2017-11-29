using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using GraphQL.Types;

namespace GraphQLSpike
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      var schema = ConfigureGraphQL();
      services.AddSingleton(typeof(ISchema), schema);
      services.AddMvc();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseMvc();
    }

    public ISchema ConfigureGraphQL()
    {
      var schema = Schema.For(@"
        type Film {
          film_id: Int
          title: String
          description: String
        }

        type Query {
          film(film_id: Int): Film
          films: [Film]
        }
      ", conf =>
      {
        conf.Types.Include<Query>();
      });

      return schema;
    }
  }
}
