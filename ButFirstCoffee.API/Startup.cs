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
using ButFirstCoffee.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using AutoMapper;

namespace ButFirstCoffee.API
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CoffeeContext>(cfg =>
            {
                cfg.UseSqlServer(_config.GetConnectionString("CoffeeConnectionString"));
            });

            services.AddAutoMapper();

            services.AddTransient<CoffeeSeeder>();

            services.AddTransient<IBeverageRepository, BeverageRepository>();
            services.AddTransient<IBeverageCategoryRepository, BeverageCategoryRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<ISaleRepository, SaleRepository>();
            services.AddTransient<ICondimentRepository, CondimentRepository>();

            services.AddMvc()
                .AddJsonOptions(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Seed the database
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    // TODO using this kind of scope can be a little bit expensive, 
                    //figure something out for production

                    var seeder = scope.ServiceProvider.GetService<CoffeeSeeder>();
                    seeder.Seed();
                }

                app.UseCors((cors) => cors.AllowAnyOrigin());
            }

            app.UseCors((cors) => cors.AllowAnyOrigin());
            if (env.IsProduction())
            {
                //TODO - implement customer frindly error handling

               // app.UseCors((cors) => cors.WithOrigins("Angular app URL")); //TODO replace AZURE WEBAPI URL with a setting, that can be overridden
            }

            app.UseMvc();
        }
    }
}
