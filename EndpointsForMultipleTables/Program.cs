using EndpointsForMultipleTables.Models;
using Microsoft.EntityFrameworkCore;
using EndpointsForMultipleTables.Controllers;
using EndpointsForMultipleTables.Repo;
using EndpointsForMultipleTables.Interface;
using EndpointsForMultipleTables;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var provider = builder.Services.BuildServiceProvider();
var config = provider.GetRequiredService<IConfiguration>();
builder.Services.AddDbContext<TaskDatabaseContext>(item => item.UseSqlServer(config.GetConnectionString("dbcs")));

builder.Services.AddScoped<IDepartment, DepartmentRepository>();
builder.Services.AddScoped<IEmployee, EmployeeRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddRepository();
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
