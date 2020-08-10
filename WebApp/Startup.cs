using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BicyleRentalsApp.Repository;
using BicyleRentalsApp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddHttpClient<ICityBikService, CityBikService>();
            services.AddSingleton<IUserRepository, UserRepository>()
                    .AddSingleton<ILocationRepository, LocationRepository>()
                    .AddSingleton<IStationRepository, StationRepository>()
                    .AddSingleton<ILocationStationService, LocationStationService>()
                    .AddSingleton<IUserService, UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory )
        {
            loggerFactory.AddFile("Logs/myapp-{Date}.txt");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseRouting();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=User}/{action=index}/{id?}"
                    );
            });
        }
    }
}
