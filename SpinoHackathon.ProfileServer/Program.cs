using Microsoft.AspNetCore.Components.Authorization;
using SpinoHackathon.ProfileServer.Endpoints;
using SpinoHackathon.ProfileServer.Services;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.AddAzureCosmosClient("spinohackathon-db");
builder.Services.AddSingleton<ICosmosService, CosmosService>();

builder.Services.AddHttpClient<IdentityServeHttpClient>(options =>
{
    options.BaseAddress = new Uri("http://identityserver");
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapProfileEndpoint();

app.Run();
