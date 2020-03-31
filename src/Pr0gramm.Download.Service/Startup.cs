using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Pr0gramm.Download.Service.Abstraction;
using Pr0gramm.Download.Service.Clients;
using Pr0gramm.Download.Service.Clients.Abstraction;
using Pr0gramm.Download.Service.Repositorys;
using Pr0gramm.Download.Service.Repositorys.Abstraction;

namespace Pr0gramm.Download.Service
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();
      services.AddHttpClient();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc(Constants.Version.ToString(), new OpenApiInfo
        {
          Title = "Pr0gramm Download Service",
          Version = Constants.Version.ToString(),
          Description = "This service works only for sfw content."
        });
        c.IncludeXmlComments($"{Assembly.GetExecutingAssembly().GetName().Name}.xml");
      });

      services.AddSingleton<ICommonRepository, CommonRepository>();
      services.AddSingleton<IPr0grammClient, Pr0grammClient>();
      services.AddSingleton<IRateLimiter, RateLimiter>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

      app.UseRouting();
      app.UseSwagger();
      app.UseSwaggerUI(c =>
      {
        c.RoutePrefix = "";
        c.SwaggerEndpoint($"/swagger/{Constants.Version.ToString()}/swagger.json",
          $"Pr0gramm Download Service v{Constants.Version.ToString()}");
      });

      app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
  }
}