using Microsoft.Azure.Cosmos;
using System.Net;

namespace SpinoHackathon.IdentityServer.Services
{
    public class CosmosService: ICosmosService
    {
        private readonly CosmosClient _client;
        private readonly Container _container;

        public CosmosService(CosmosClient client)
        {
            _client = client;
            client.CreateDatabaseIfNotExistsAsync("Identity").Wait();

            _container = client.GetDatabase("Identity").CreateContainerIfNotExistsAsync("Users", "/UserName").Result;
        }

        public async Task<ApplicationUser> GetUserById(string id)
        {
            try
            {
                ItemResponse<ApplicationUser> response = await _container.ReadItemAsync<ApplicationUser>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<ApplicationUser> GetUserByEmail(string email)
        {
            QueryDefinition queryDefinition = new QueryDefinition("SELECT * FROM c WHERE c.Email = @Email")
                .WithParameter("@Email", email);

            FeedIterator<ApplicationUser> feedIterator = _container.GetItemQueryIterator<ApplicationUser>(queryDefinition);
            List<ApplicationUser> users = new List<ApplicationUser>();

            while (feedIterator.HasMoreResults)
            {
                FeedResponse<ApplicationUser> response = await feedIterator.ReadNextAsync();
                users.AddRange(response);
            }

            return users.FirstOrDefault();
        }

        public async Task<ApplicationUser> CreateUser(ApplicationUser user)
        {
            ItemResponse<ApplicationUser> response = await _container.CreateItemAsync(user, new PartitionKey(user.UserName));
            return response.Resource;
        }

        public async Task<ApplicationUser> UpdateUser(ApplicationUser user)
        {
            ItemResponse<ApplicationUser> response = await _container.UpsertItemAsync(user, new PartitionKey(user.UserName));
            return response.Resource;
        }

        public async void DeleteUser(string id)
        {
            var data = await _container.GetItemLinqQueryable<ApplicationUser>(true).Where(x => x.Id == id).FirstAsync();
            await _container.DeleteItemAsync<ApplicationUser>(id, new PartitionKey(data.UserName));
        }
    }
}
