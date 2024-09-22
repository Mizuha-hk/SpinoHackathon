namespace SpinoHackathon.Domain.Events
{
    public class PostUnLikeDomainEvent : INotification
    {
        public Post Post { get; }
        public User User { get; }

        public PostUnLikeDomainEvent(Post post, User user)
        {
            Post = post;
            User = user;
        }
    }
}
