using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

var Configuration = builder.Configuration;

string connectinString = "Host=" + Environment.GetEnvironmentVariable("DB_HOST")
    + ";Port=" + Environment.GetEnvironmentVariable("DB_PORT")
    + ";Database=" + Environment.GetEnvironmentVariable("DB_USER")
    + ";Username=" + Environment.GetEnvironmentVariable("DB_PASSWORD")
    + ";Password=" + Environment.GetEnvironmentVariable("DB_NAME") + ";";

Console.WriteLine(connectinString);

builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(connectinString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
