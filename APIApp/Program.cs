using BLL.Services;
using DAL.EF;
using DAL.Repos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ProductService>(); // DI, Registering ProductService for Dependency Injection
builder.Services.AddScoped<ProductRepo>(); // DI, Registering ProductRepo for Dependency Injection
builder.Services.AddScoped<CategoryService>(); // DI, Registering CategoryService for Dependency Injection
builder.Services.AddScoped<CategoryRepo>(); // DI, Registering CategoryRepo for Dependency Injection
builder.Services.AddDbContext<PMSContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConn")); // DI, Telling PMSContext to use SQL Server with connection string from appsettings.json
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
