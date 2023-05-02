using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

//Ocetol Setup
var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

builder.Configuration.AddJsonFile($"ocelot.{env}.json", optional: false, reloadOnChange: true);

builder.Services.AddOcelot(builder.Configuration);
//

var app = builder.Build();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//Use Ocelot
await app.UseOcelot();

app.Run();
