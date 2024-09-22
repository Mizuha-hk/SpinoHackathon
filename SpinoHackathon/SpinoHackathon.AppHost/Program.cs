var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.SpinoHackathon_RealtimeServer>("spinohackathon-realtimeserver");

builder.AddProject<Projects.SpinoHackathon_IdentityServer>("spinohackathon-identityserver");

builder.AddProject<Projects.SpinoHackathon_PostServer>("spinohackathon-postserver");

builder.AddProject<Projects.SpinoHackathon_NotificationServer>("spinohackathon-notificationserver");

builder.AddProject<Projects.SpinoHackathon_Client>("spinohackathon-client");

builder.Build().Run();
