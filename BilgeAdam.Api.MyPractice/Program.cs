using BilgeAdam.Common;
using BilgeAdam.Data.Context;
using BilgeAdam.Services.Abstractions;
using BilgeAdam.Services.Concretes;
using BilgeAdam.Services.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var settings = builder.Configuration.GetSection("Settings").Get<Settings>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//DbContext

builder.Services.AddDbContext<NorthwindDbContext>(options =>
{
    options.UseSqlServer(settings.Database.ConnectionString);
});

// Data Services 

builder.Services.AddDataServices();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
