namespace SpinoHackathon.Domain.Events
{
    public class PostCreatedDomainEvent : INotification
    {
        public Post Post { get; }

        public PostCreatedDomainEvent(Post post)
        {
            Post = post;
        }
    }
}
