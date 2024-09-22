namespace SpinoHackathon.Domain.Events
{
    public class CommentUpdatedDomainEvent
    {
        public Comment Comment { get; }

        public Post TargetPost { get; }

        public CommentUpdatedDomainEvent(Comment comment, Post targetPost)
        {
            Comment = comment;
            TargetPost = targetPost;
        }
    }
}
