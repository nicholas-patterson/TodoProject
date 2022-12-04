using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TodoProject.Application.Abstractions;
using TodoProject.Infrastructure.Context;
using TodoProject.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ITodoRepository, TodoRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var conStrBuilder = new SqlConnectionStringBuilder(
    builder.Configuration.GetConnectionString("Default"));

conStrBuilder.Password = builder.Configuration["DbPassword"];
conStrBuilder.UserID = builder.Configuration["DbId"];

var connection = conStrBuilder.ConnectionString;

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(connection);
});

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
