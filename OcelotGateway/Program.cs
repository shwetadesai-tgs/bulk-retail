using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using OcelotGateway.Handlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

//Ocetol Setup
var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

builder.Configuration.AddJsonFile($"ocelot.{env}.json", optional: false, reloadOnChange: true);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.Authority = "https://localhost:44366";
    o.Audience = "AuthenticationAPI";
    o.RequireHttpsMetadata = false;
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("PublicSecure", policy => policy.RequireClaim("client_id", "zuber@tgs.com"));
});

//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("PublicSecure", policy =>
//    {
//        //policy.RequireClaim("client_id", "zuber@tgs.com");
//        policy.RequireAuthenticatedUser();
//        policy.AddRequirements(new RoleLevelRequirement("Admin"));
//    });
//});

builder.Services.AddScoped<IAuthorizationHandler, RoleLevelHandler>();

builder.Services.AddOcelot(builder.Configuration);
//

var app = builder.Build();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//Use Ocelot
await app.UseOcelot();

app.Run();
