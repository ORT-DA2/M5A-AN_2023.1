using Microsoft.EntityFrameworkCore;
using DataAccess;
using BusinessLogic;
using IBusinessLogic;
using IDataAccess;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ProducesAttribute("application/json", "text/plain", "text/json"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// var connection = @"Data Source=.\SQLSERVER19; Initial Catalog=UyflixDb; Integrated Security=true;";
// var connection = @"Data Source=tcp:localhost,1433; Initial Catalog=UyflixDB; User ID=SA;Password=Pass1234";
// builder.Services.AddDbContext<UyflixContext>(options => options.UseSqlServer(connection));
builder.Services.AddDbContext<UyflixContext>();

builder.Services.AddScoped<IMoviesService, MoviesService>();
builder.Services.AddScoped<IMoviesManagement, MoviesManagement>();

builder.Services.AddCors(c =>
{
    c.AddPolicy("CorsPolicy", options =>
        options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();

