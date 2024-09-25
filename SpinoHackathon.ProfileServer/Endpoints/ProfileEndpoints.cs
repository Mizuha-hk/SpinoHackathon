using Azure.Core.GeoJson;
using Microsoft.AspNetCore.Http.HttpResults;
using SpinoHackathon.ProfileServer.Models;
using SpinoHackathon.ProfileServer.Models.RequestModel;
using SpinoHackathon.ProfileServer.Models.ResponseModel;
using SpinoHackathon.ProfileServer.Services;

namespace SpinoHackathon.ProfileServer.Endpoints
{
    public static class ProfileEndpoints
    {
        public static IEndpointRouteBuilder MapProfileEndpoint(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/profile").HasApiVersion(1.0);

            group.MapGet("/{userName}", Results<Ok<ProfileResponse>, NotFound> (
                ICosmosService cosmos,
                string userName) =>
            {
                var profile = cosmos.GetUserProfile(userName);

                if (profile == null)
                {
                    return TypedResults.NotFound();
                }

                return TypedResults.Ok(new ProfileResponse
                {
                    UserName = profile.UserName,
                    DisplayName = profile.DisplayName,
                    Bio = profile.Bio,
                    IconUrl = profile.IconUrl
                });
            }).WithName("GetUserProfile").WithOpenApi();

            group.MapPost("/Create", async Task<Results<Ok, UnauthorizedHttpResult>> (
                ICosmosService cosmos,
                ProfileCreateModel model,
                IdentityServeHttpClient httpclient) =>
            {
                string id;
                try
                {
                    var response = await httpclient.GetUserIdByToken(model.Token);
                    if (response is null)
                    {
                        return TypedResults.Unauthorized();
                    }
                    id = response.Id;
                }
                catch (Exception e)
                {
                    return TypedResults.Unauthorized();
                }

                await cosmos.CreateUserProfile(new Profile
                {
                    Id = Guid.NewGuid().ToString(),
                    UserId = id,
                    UserName = model.UserName,
                    DisplayName = model.DisplayName,
                    Bio = model.Bio,
                    IconUrl = model.IconUrl,
                    Followers = 0,
                    Following = 0
                });

                return TypedResults.Ok();
            }).WithName("CreateProfile").WithOpenApi();

            group.MapPut("/Update", async Task<Results<Ok, UnauthorizedHttpResult>> (
                ICosmosService cosmos,
                ProfileCreateModel model,
                IdentityServeHttpClient httpclient) =>
            {
                string id;
                try
                {
                    var response = await httpclient.GetUserIdByToken(model.Token);
                    if (response is null)
                    {
                        return TypedResults.Unauthorized();
                    }
                    id = response.Id;
                }
                catch (Exception e)
                {
                    return TypedResults.Unauthorized();
                }

                await cosmos.UpdateUserProfile(new Profile
                {
                    UserId = id,
                    UserName = model.UserName,
                    DisplayName = model.DisplayName,
                    Bio = model.Bio,
                    IconUrl = model.IconUrl
                });

                return TypedResults.Ok();
            }).WithName("UpdateProfile").WithOpenApi(); 

            group.MapGet("/Followers/{userName}", Results<Ok<IEnumerable<Follower>>, NotFound> (
                ICosmosService cosmos,
                string userName) =>
            {
                var followers = cosmos.GetFollowers(userName);

                if (followers == null)
                {
                    return TypedResults.NotFound();
                }

                return TypedResults.Ok(followers);
            }).WithName("GetFollowers").WithOpenApi();

            group.MapGet("/Following/{userName}", Results<Ok<IEnumerable<Following>>, NotFound> (
                ICosmosService cosmos,
                string userName) =>
            {
                var following = cosmos.GetFollowing(userName);

                if (following == null)
                {
                    return TypedResults.NotFound();
                }

                return TypedResults.Ok(following);
            }).WithName("GetFollowing").WithOpenApi();

            group.MapPost("/AddFollowing", async Task<Results<Ok, UnauthorizedHttpResult>> (
                ICosmosService cosmos,
                FollowingModel model,
                IdentityServeHttpClient httpclient) =>
            {
                string id;
                try
                {
                    var response = await httpclient.GetUserIdByToken(model.Token);
                    if (response is null)
                    {
                        return TypedResults.Unauthorized();
                    }
                    id = response.Id;
                }
                catch (Exception e)
                {
                    return TypedResults.Unauthorized();
                }

                await cosmos.AddFollowing(model.UserName, model.FollowingName);

                await cosmos.AddFollower(model.FollowingName, model.UserName);

                return TypedResults.Ok();
            }).WithName("AddFollower").WithOpenApi();

            group.MapDelete("/RemoveFollowing", async Task<Results<Ok, UnauthorizedHttpResult>> (
                ICosmosService cosmos,
                FollowingModel model,
                IdentityServeHttpClient httpclient) =>
            {
                string id;
                try
                {
                    var response = await httpclient.GetUserIdByToken(model.Token);
                    if (response is null)
                    {
                        return TypedResults.Unauthorized();
                    }
                    id = response.Id;
                }
                catch (Exception e)
                {
                    return TypedResults.Unauthorized();
                }

                await cosmos.RemoveFollowing(model.UserName, model.FollowingName);
                await cosmos.RemoveFollower(model.FollowingName, model.UserName);

                return TypedResults.Ok();
            }).WithName("RemoveFollowing").WithOpenApi();

            return app;
        }
    }
}
