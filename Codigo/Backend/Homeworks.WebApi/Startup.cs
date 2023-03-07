using Homeworks.BusinessLogic;
using Homeworks.BusinessLogic.Interface;
using Homeworks.DataAccess;
using Homeworks.DataAccess.Interface;
using Homeworks.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Homeworks.WebApi
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

            /*services.AddDbContext<DbContext, HomeworksContext>(
                o => o.UseSqlServer(Configuration.GetConnectionString("HomeworksDB"))
            );*/
            services.AddDbContext<DbContext, HomeworksContext>(
                o => o.UseInMemoryDatabase("HomeworksDB")
            );
            services.AddScoped<ILogic<Homework>, HomeworkLogic>();
            services.AddScoped<IRepository<Homework>, HomeworkRepository>();
            services.AddScoped<ISessionLogic, SessionLogic>();
            services.AddScoped<ILogic<User>, UserLogic>();
            services.AddScoped<IRepository<User>, UserRepository>();

            services.AddCors(options => {
                options.AddPolicy("DefaultPolicy", builder => 
                    builder
                       .AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                );
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("DefaultPolicy");
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        
    }
}
