namespace SpinoHackathon.Domain.Aggregates.Notification
{
    public class NotificationType : Enumeration, IAggregateRoot
    {
        public static NotificationType Comment = new NotificationType(1, nameof(Comment));
        public static NotificationType Like = new NotificationType(2, nameof(Like));
        public static NotificationType Follow = new NotificationType(3, nameof(Follow));

        public NotificationType(int id, string name) : base(id, name) { }
    }
}
