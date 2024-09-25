using Microsoft.Azure.Cosmos;
using SpinoHackathon.ProfileServer.Models;

namespace SpinoHackathon.ProfileServer.Services
{
    public class CosmosService : ICosmosService
    {
        private readonly CosmosClient _client;
        private readonly Container _container;

        public CosmosService(CosmosClient client)
        {
            _client = client;
            client.CreateDatabaseIfNotExistsAsync("Profile").Wait();

            _container = client.GetDatabase("Profile").CreateContainerIfNotExistsAsync("Profiles", "/UserId").Result;
        }

        public async Task AddFollower(string userName, string followerName)
        {
            var followerInfo = GetUserProfile(followerName);

            var follower = new Follower
            {
                Id = Guid.NewGuid().ToString(),
                UserName = userName,
                FollowerName = followerName,
                FollowerDisplayName = followerInfo.DisplayName,
                IconUrl = followerInfo.IconUrl
            };

            await _container.CreateItemAsync(follower, new PartitionKey(follower.UserName));

            var profile = GetUserProfile(follower.UserName);
            profile.Followers++;
            await UpdateUserProfile(profile);
        }

        public async Task AddFollowing(string userName, string followingName)
        {
            var followingInfo = GetUserProfile(followingName);

            var following = new Following
            {
                Id = Guid.NewGuid().ToString(),
                UserName = userName,
                FollowingName = followingName,
                FollowingDisplayName = followingInfo.DisplayName,
                IconUrl = followingInfo.IconUrl
            };

            await _container.CreateItemAsync(following, new PartitionKey(following.UserName));
            var profile = GetUserProfile(following.UserName);
            profile.Following++;
            await UpdateUserProfile(profile);
        }

        public async Task CreateUserProfile(Profile profile)
        {
            await _container.CreateItemAsync(profile, new PartitionKey(profile.UserName));
        }

        public IEnumerable<Follower> GetFollowers(string userName)
        {
            var result = _container.GetItemLinqQueryable<Follower>()
                .Where(f => f.UserName == userName && f.Type == "Follower")
                .ToList();

            return result;
        }

        public IEnumerable<Following> GetFollowing(string userName)
        {
            var result = _container.GetItemLinqQueryable<Following>()
                .Where(f => f.UserName == userName && f.Type == "Following")
                .ToList();

            return result;
        }

        public Profile GetUserProfile(string userName)
        {
            var result = _container.GetItemLinqQueryable<Profile>()
                .Where(p => p.UserName == userName && p.Type == "Profile")
                .ToList()
                .FirstOrDefault();

            if (result == null)
            {
                throw new Exception("Profile not found");
            }

            return result;
        }

        public async Task RemoveFollower(string userName, string followerName)
        {
            var follower = _container.GetItemLinqQueryable<Follower>()
                .Where(f => f.UserName == userName && f.Type == "follower" && f.FollowerName == followerName)
                .ToList()
                .FirstOrDefault();

            if (follower == null)
            {
                throw new Exception("Follower not found");
            }

            await _container.DeleteItemAsync<Follower>(follower.Id, new PartitionKey(userName));

            var profile = GetUserProfile(userName);
            profile.Followers--;
            await UpdateUserProfile(profile);
        }

        public async Task RemoveFollowing(string userName, string followingName)
        {
            var following = _container.GetItemLinqQueryable<Following>()
                .Where(f => f.UserName == userName && f.Type == "Following" && f.FollowingName == followingName)
                .ToList()
                .FirstOrDefault();

            if (following == null)
            {
                throw new Exception("Following not found");
            }
            
            await _container.DeleteItemAsync<Following>(following.Id, new PartitionKey(userName));

            var profile = GetUserProfile(userName);
            profile.Following--;
            await UpdateUserProfile(profile);
        }

        public Task UpdateUserProfile(Profile profile)
        {
            var profileToUpdate = _container.GetItemLinqQueryable<Profile>()
                .Where(p => p.UserId == profile.UserId && p.Type == "Profile")
                .ToList()
                .FirstOrDefault();

            if (profileToUpdate == null)
            {
                throw new Exception("Profile not found");
            }

            profileToUpdate.DisplayName = profile.DisplayName;
            profileToUpdate.Bio = profile.Bio;
            profileToUpdate.IconUrl = profile.IconUrl;
            profileToUpdate.Followers = profile.Followers;
            profileToUpdate.Following = profile.Following;

            return _container.ReplaceItemAsync(profileToUpdate, profileToUpdate.Id, new PartitionKey(profileToUpdate.UserName));
        }
    }
}
