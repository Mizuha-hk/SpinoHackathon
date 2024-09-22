namespace SpinoHackathon.Domain.Events
{
    public class PostLikeDomainEvent : INotification
    {
        public Post Post { get; }
        public User User { get; }

        public PostLikeDomainEvent(Post post, User user)
        {
            Post = post;
            User = user;
        }
    }
}
