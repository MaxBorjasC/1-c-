using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using webApp.Persistence;
using webApp.Core;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace webApp
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
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllHeaders",
                      builder =>
                      {
                          builder.AllowAnyOrigin()
                                 .AllowAnyHeader()
                                 .AllowAnyMethod();
                      });
            });

            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper();

            services.AddMvc();
            services.AddEntityFrameworkSqlServer();
            //services.AddDbContext<VegaDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));

            services.AddDbContext<VegaDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]);
               

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            // Shows UseCors with CorsPolicyBuilder.

            //app.UseCors(builder =>
            //   builder.WithOrigins("http://localhost:4200"));

            app.UseCors("AllowAllHeaders");
            //app.UseCors(
            //    options => options.WithOrigins("http://localhost:4200")
            //                                    .AllowAnyMethod()
            //                                    .WithMethods("GET", "PUT", "POST", "DELETE", "OPTIONS")
            //);

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });



            //var serviceScopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            //using (var serviceScope = serviceScopeFactory.CreateScope())
            //{
            //    var dbContext = serviceScope.ServiceProvider.GetService<VegaDbContext>();
            //    dbContext.Database.EnsureDeleted();
            //    dbContext.Database.EnsureCreated();
            //}
        }
    }
}
