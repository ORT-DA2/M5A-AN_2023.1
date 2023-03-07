using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bierland.businesslogic;
using Bierland.businesslogicInterface;
using Bierland.dataaccess;
using Bierland.dataaccessInterface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Bierland.webapi.Filters;

namespace Bierland.webapi
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
           services.AddCors(cors =>
            {
                cors.AddPolicy("BierlandPolicy", options =>
                {
                    options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling =
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            }); ;

            services.AddDbContext<DbContext, BierlandContext>(
                o => o.UseSqlServer(Configuration.GetConnectionString("Bierland"))
            );

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IPubLogic, PubLogic>();
            services.AddScoped<IBeerLogic, BeerLogic>();
            services.AddScoped<IBeerFactoryLogic, BeerFactoryLogic>();
            services.AddScoped<IUserLogic, UserLogic>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<AuthorizationFilter>();

            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"Bierland {groupName}",
                    Version = groupName,
                    Description = "Bierland",
                    Contact = new OpenApiContact
                    {
                        Name = "Bierland",
                        Email = string.Empty,
                        Url = new Uri("https://beer.fandom.com/"),
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bierland API");
            });

            app.UseRouting();

            app.UseCors("BierlandPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
