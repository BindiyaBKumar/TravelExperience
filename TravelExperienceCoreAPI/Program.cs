using System;
using TravelExperienceCoreAPI.Data;
using Microsoft.EntityFrameworkCore;
using TravelExperienceCoreAPI.Services;
using TravelExperienceCoreAPI.Helpers;
using TravelExperienceCoreAPI.Interfaces;
using TravelExperienceCoreAPI.Repositories;
;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("TravelConnection");

builder.Services.AddDbContext<TravelExperienceDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<ITravelExperienceService, TravelExperienceService>();
builder.Services.AddScoped<IActivityRepository, ActivityRepository>();
builder.Services.AddScoped<ITripRepository, TripRepository>();
builder.Services.AddScoped<ValidateUserInput>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
