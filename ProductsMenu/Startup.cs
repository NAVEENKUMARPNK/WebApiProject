using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SendingMail;
using DataAccessLayer;
using DataAccessLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace ProductsMenu
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            
            var Connection = configuration.GetConnectionString("DbConnection");
            var fromaddress = configuration.GetValue<string>("SMTP:Fromaddress");
            var password  = configuration.GetValue<string>("SMTP:Password");
            Configuration = configuration;
        }
       
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var Connection = Configuration.GetConnectionString("DbConnection");
            services.AddDbContext<LocationDbContext>(options => options.UseSqlServer(Connection));
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ILocationinterface, LocationRepository>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProductsMenu", Version = "v1" });
            });
            //services.AddControllers();
            //services.AddSingleton<Mailsending>();
            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProductsMenu v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
