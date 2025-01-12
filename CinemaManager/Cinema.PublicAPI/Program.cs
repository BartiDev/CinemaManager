using Cinema.Domain.Interfaces;
using Cinema.Domain.Mappings;
using Cinema.Domain.Services;
using Cinema.Infrastructure.Data;
using Cinema.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Data base configuraiton
builder.Services.AddScoped<CinemaDbContext>();

builder.Services.AddDbContext<CinemaDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("CinemaDB"));
});

//AutoMapper configuration
builder.Services.AddAutoMapper(typeof(MappingProfile));

//Generic repositories
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

//Generic services
builder.Services.AddScoped(typeof(IReadServiceAsync<,>), typeof(ReadServiceAsync<,>));
builder.Services.AddScoped(typeof(IGenericService<,>), typeof(GenericService<,>));

//Asset mappings
builder.Services.AddScoped<IMovieMapping, MovieMapping>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
