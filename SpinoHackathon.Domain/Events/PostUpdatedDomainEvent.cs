namespace SpinoHackathon.Domain.Events
{
    public class PostUpdatedDomainEvent : INotification
    {
        public Post Post { get; }

        public PostUpdatedDomainEvent(Post post)
        {
            Post = post;
        }
    }
}
