namespace SpinoHackathon.Domain.Aggregates.User
{
    public interface IUserRepository : IRepository<User>
    {
        User Add(User user);
        User Update(User user);      
        Task<User> FindAsync(string identityGuid);
        Task<User> FindByIdAsync(int id);

        Task<Profile> FindByNameAsync(string name);
        Task<Profile> FindByNameAsync(string name, CancellationToken cancellationToken);

        Task<Profile> AddFollowerAsync(Profile profile, Profile follower);
        Task<Profile> RemoveFollowerAsync(Profile profile, Profile follower);
    }
}
