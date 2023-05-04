using BulkRetail.ProductService.Data;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Product.Core.IRepositories;
using Product.Core.IServices;
using Product.Infrastructure.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Sql Dependency Injection
var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(ConnectionString));
#pragma warning disable CS8603 // Possible null reference return.
builder.Services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
#pragma warning restore CS8603 // Possible null reference return.

#pragma warning disable CS0618 // Type or member is obsolete
builder.Services.AddControllers()
    .AddFluentValidation(options =>
    {
        // Validate child properties and root collection elements
#pragma warning disable CS0618 // Type or member is obsolete
        options.ImplicitlyValidateChildProperties = true;
#pragma warning restore CS0618 // Type or member is obsolete
#pragma warning disable CS0618 // Type or member is obsolete
        options.ImplicitlyValidateRootCollectionElements = true;
#pragma warning restore CS0618 // Type or member is obsolete

        // Automatic registration of validators in assembly
#pragma warning disable CS0618 // Type or member is obsolete
        options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
#pragma warning restore CS0618 // Type or member is obsolete
    });
#pragma warning restore CS0618 // Type or member is obsolete

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductServices, ProductServices>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

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
