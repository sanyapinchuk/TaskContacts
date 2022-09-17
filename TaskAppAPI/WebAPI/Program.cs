using Application.Logger.Extension;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Data.Entity;
using WebAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

//add logger
builder.Logging.SetLogFile(Path.Combine(Directory.GetCurrentDirectory(), "log.txt"));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddPersistence(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}

app.UseCustomExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
