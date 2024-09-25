using SpinoHackathon.ProfileServer.Models;

namespace SpinoHackathon.ProfileServer.Services
{
    public interface ICosmosService
    {
        Task CreateUserProfile(Profile profile);
        Profile GetUserProfile(string userName);
        Task UpdateUserProfile(Profile profile);

        Task AddFollower(string userName, string followerName);
        Task RemoveFollower(string userName, string followerName);
        IEnumerable<Follower> GetFollowers(string userId);

        Task AddFollowing(string userName, string followingName);
        Task RemoveFollowing(string userName, string followingName);
        IEnumerable<Following> GetFollowing(string userId);
    }
}
