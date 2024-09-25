using Microsoft.Extensions.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var cosmos = builder.AddAzureCosmosDB("spinohackathon-db");

var cosmosDb = cosmos.AddDatabase("cosmosdb");

if (builder.Environment.IsDevelopment())
{
    cosmosDb
        .WithHttpsEndpoint(8081,8081, "emulator-port")
        .RunAsEmulator();
}

// Services
builder.AddProject<Projects.SpinoHackathon_RealtimeServer>("realtimeserver");

var identityServer = builder.AddProject<Projects.SpinoHackathon_IdentityServer>("identityserver")
    .WithReference(cosmosDb);

var profileServer = builder.AddProject<Projects.SpinoHackathon_ProfileServer>("profileserver")
    .WithReference(identityServer)
    .WithReference(cosmosDb);

builder.AddProject<Projects.SpinoHackathon_PostServer>("postserver")
    .WithReference(identityServer)
    .WithReference(cosmosDb);

builder.AddProject<Projects.SpinoHackathon_NotificationServer>("notificationserver");

var webApp = builder.AddProject<Projects.SpinoHackathon_WebApp>("webapp")
    .WithReference(profileServer);

builder.Build().Run();