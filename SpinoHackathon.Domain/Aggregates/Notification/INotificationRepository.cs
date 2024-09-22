namespace SpinoHackathon.Domain.Aggregates.Notification
{
    public interface INotificationRepository : IRepository<Notification>
    {
        Notification Add(Notification notification);
        Task<List<Notification>> FindByNotifyUserIdAsync(string userId, CancellationToken cancellationToken);
    }
}
