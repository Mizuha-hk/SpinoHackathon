namespace SpinoHackathon.Domain.Aggregates.Notification
{
    public class Notification : Entity, IAggregateRoot
    {
        public NotificationType Type { get; private set; }
        public string Message { get; private set; }
        public bool IsRead { get; private set; }
        public string NotifyUser { get; private set; }
        public Profile? ActUser { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public Notification(NotificationType type, string message, string notifyUser , Profile? profile)
        {
            ArgumentNullException.ThrowIfNull(type);
            ArgumentNullException.ThrowIfNull(message);

            Type = type;
            Message = message;
            NotifyUser = notifyUser;
            IsRead = false;
            ActUser = profile;
            CreatedAt = DateTime.UtcNow;
        }

        public void Read()
        {
            IsRead = true;
        }
    }
}
