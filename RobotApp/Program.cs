using AutoMapper;
using BL.Helpers;
using BL.Logic;
using DAL.Data;
using DAL.Functions.Interfaces;
using DAL.Functions.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers();
builder.Services.AddScoped<ISurvivorRepository, SurvivorRepository>();
builder.Services.AddScoped<SurvivorBL>();
builder.Services.AddScoped<IRobotRepository, RobotRepository>();
builder.Services.AddScoped<RobotBL>();

builder.Services.AddAutoMapper(typeof(MapperInitializer));
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
