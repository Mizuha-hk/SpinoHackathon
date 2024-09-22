namespace SpinoHackathon.Domain.Aggregates.Post
{
    public class Post : PostBase
    {
        public int CommentCount => _comments.Count;

        private List<Comment> _comments;

        public IReadOnlyCollection<Comment> Comments => _comments.AsReadOnly();

        public Post(Profile author, string content, string?[] assetUrls) : base(author, content, assetUrls)
        {
            _comments = new List<Comment>();
        }

        public void AddComment(Comment comment)
        {
            ArgumentNullException.ThrowIfNull(comment);

            _comments.Add(comment);
        }

        public void RemoveComment(Comment comment)
        {
            ArgumentNullException.ThrowIfNull(comment);

            _comments.Remove(comment);
        }
    }
}
