namespace SpinoHackathon.Domain.Events
{
    public class CommentCreatedDomainEvent
    {
        public Comment Comment { get; }

        public Post TargetPost { get; }

        public CommentCreatedDomainEvent(Comment comment, Post targetPost)
        {
            Comment = comment;
            TargetPost = targetPost;
        }
    }
}
