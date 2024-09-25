namespace SpinoHackathon.IdentityServer.Services
{
    public interface ICosmosService
    {
        Task<ApplicationUser> GetUserById(string id);
        Task<ApplicationUser> GetUserByEmail(string email);
        Task<ApplicationUser> CreateUser(ApplicationUser user);
        Task<ApplicationUser> UpdateUser(ApplicationUser user);
        void DeleteUser(string id);
    }
}
