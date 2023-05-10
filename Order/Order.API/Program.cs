using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Order.Core;
using Order.Core.IRepositories;
using Order.Core.IServices;
using Order.Infrastructure.Repositories;
using Order.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAutoMapper(typeof(Program).Assembly);

//SQLConnection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString));

//Resolve DI
builder.Services.AddScoped<IMapper, Mapper>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderDetailServices, OrderDetailService>();
builder.Services.AddScoped<IOrderRepositories, OrderRepository>();
builder.Services.AddScoped<IOrderDetailRepositories, OrderDetailRepository>();
builder.Services.AddScoped<IOrderRepositories, OrderRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


// Add services to the container.
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
