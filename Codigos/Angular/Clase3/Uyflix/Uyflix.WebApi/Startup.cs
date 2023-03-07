using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Uyflix.IBusinessLogic;
using Uyflix.BusinessLogic;
using Uyflix.IDataAccess;
using Uyflix.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Uyflix.WebApi
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
            var connection = @"Data Source=.\SQLSERVER19; Initial Catalog=UyflixDb; Integrated Security=true;";
            services.AddDbContext<UyflixContext>(options => options.UseSqlServer(connection));
            services.AddControllers();
            services.AddScoped<IMoviesService, MoviesService>();
            services.AddScoped<IMoviesManagement, MoviesManagement>();
            services.AddScoped<ISeriesService, SeriesService>();
            services.AddScoped<ISeriesManagement, SeriesManagement>();
            services.AddScoped<IDocumentariesService, DocumentariesService>();
            services.AddScoped<IDocumentariesManagement, DocumentariesManagement>();

            services.AddCors(c =>
            {
                c.AddPolicy("CorsPolicy", options =>
                    options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UyflixContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            db.Database.EnsureCreated();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
