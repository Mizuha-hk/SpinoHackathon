using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Http.HttpResults;
using SpinoHackathon.IdentityServer.Models.Arguments;
using System.Net.Http.Headers;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
namespace SpinoHackathon.IdentityServer.Endpoints;

public static class AuthenticationEndpoints
{
    public static void MapApplicationUserEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/authentication").WithTags(nameof(ApplicationUser));

        group.MapPost("/login", async Task<Results<Ok<TokenResult>, UnauthorizedHttpResult>> (
            ICosmosService cosmos,
            ITokenService tokenService,
            LoginArgument arg) =>
        {
            var user = await cosmos.GetUserByEmail(arg.Email);
            if (user is null)
            {
                return TypedResults.Unauthorized();
            }

            if (user.PasswordHash != SHA256.HashData(Encoding.UTF8.GetBytes(arg.Password)).ToString())
            {
                return TypedResults.Unauthorized();
            }

            var token = tokenService.GenerateAccessToken(user.Id, user.Email);

            return TypedResults.Ok(new TokenResult { Token = token });
        })
        .WithName("Login")
        .WithOpenApi();

        group.MapPost("/register", async Task<Results<Ok<TokenResult>, BadRequest<string>>> (
            ICosmosService cosmos,
            ITokenService tokenService,
            RegisterArgument model) =>
        {
            if (model is null)
            {
                return TypedResults.BadRequest("Model is null");
            }

            var user = await cosmos.GetUserByEmail(model.Email);
            if (user is not null)
            {
                return TypedResults.BadRequest("User already exists");
            }

            var userByName = await cosmos.GetUserById(model.UserName);
            if (userByName is not null)
            {
                return TypedResults.BadRequest("User already exists");
            }

            var userInfo = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = model.UserName,
                Email = model.Email,
                PasswordHash = SHA256.HashData(Encoding.UTF8.GetBytes(model.Password)).ToString()
            };

            await cosmos.CreateUser(userInfo);
            var token = tokenService.GenerateAccessToken(userInfo.Id, userInfo.Email);

            return TypedResults.Ok(new TokenResult { Token = token });
        })
        .WithName("Register")
        .WithOpenApi();

        group.MapPost("/Validate", Results<Ok<UserIdResult>, UnauthorizedHttpResult> (
            TokenResult token,
            ITokenService tokenService) =>
        { 
            var userId = tokenService.GetUserNameFromToken(token.Token);

            if(userId is null)
            {
                return TypedResults.Unauthorized();
            }

            return TypedResults.Ok(new UserIdResult { Id = userId });
        })
        .WithName("TokenValidate")
        .WithOpenApi();
    }
}
