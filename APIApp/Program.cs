using BLL.Services;
using DAL;
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
//builder.Services.AddScoped<ProductRepo>(); // DI, Registering ProductRepo for Dependency Injection
builder.Services.AddScoped<CategoryService>(); // DI, Registering CategoryService for Dependency Injection
builder.Services.AddScoped<DataAccessFactory>(); // DI, Registering CategoryRepo for Dependency Injection
//builder.Services.AddScoped<CategoryRepoFile>(); // DI, Registering CategoryRepoFile for Dependency Injection
builder.Services.AddScoped<OrderService>();//DI, Registering OrderService for Dependency Injection
builder.Services.AddScoped<OrderItemService>();//DI, Registering OrderItemService for Dependency Injection
builder.Services.AddScoped<PaymentService>();//DI, Registering PaymentService for Dependency Injection

//builder.Services.AddScoped(typeof(Repository<>)); // DI, Registering Generic Repository for Dependency Injection

// Configuring PMSContext to use SQL Server Database
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
