using IdentityServer.API;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityServer()
             .AddDeveloperSigningCredential()
             .AddOperationalStore(options =>
             {
                 options.EnableTokenCleanup = true;
                 options.TokenCleanupInterval = 10; // interval in seconds
             })
             .AddInMemoryApiResources(Configuration.GetApiResources())
             .AddInMemoryApiScopes(Configuration.GetApiScopes())
             .AddInMemoryClients(Configuration.GetClients());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseIdentityServer();
app.UseRouting();

app.MapGet("/", () => "Authentication services started!");

app.Run();
