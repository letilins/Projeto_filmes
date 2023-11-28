using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Filmes_2023
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddSingleton<IFilmesService, FilmesService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
    else
        {
        
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseRouting();

        app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
    }

    }
}

