using Bakery.Data;
using Bakery.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;


namespace Bakery
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            IServiceCollection services = builder.Services;

            string connection = builder.Configuration.GetConnectionString("SqlServerConnection");
            services.AddDbContext<BakeryDBContext>(options => options.UseSqlServer(connection));

            services.AddDistributedMemoryCache();
            services.AddSession();

            builder.Services.AddControllersWithViews(options => {
                options.CacheProfiles.Add("BakeryDBCache",
                    new CacheProfile()
                    {
                        Location = ResponseCacheLocation.Any,
                        Duration = 2 * 27 + 240
                    });
            });

            //MVC
            services.AddControllersWithViews();
            WebApplication app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            //
            app.UseStaticFiles();

            // 
            app.UseSession();

            // 
            app.UseDbInitializer();

            //
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            app.Run();

        }

    }
}