namespace SpinoHackathon.Domain.Aggregates.Post
{
    public interface IPostRepository : IRepository<Post>
    {
        Post Add(Post post);
        void Update(Post post);

        Task<Post> FindByIdAsync(int id);
        Task<Post> FindByIdAsync(int id, CancellationToken cancellationToken);

        Task<Comment> AddComment(Comment comment);
        Task<Comment> AddComment(Comment comment, CancellationToken cancellationToken);

        Task<Comment> RemoveComment(Comment comment);
        Task<Comment> RemoveComment(Comment comment, CancellationToken cancellationToken);

        Task<Post> AddLikeAsync(Post post, Profile profile);
        Task<Post> RemoveLikeAsync(Post post, Profile profile);

        Task<List<Post>> GetTimelineAsync(Profile profile, int page, int pageSize);
        Task<List<Post>> GetTimelineAsync(Profile profile, int page, int pageSize, CancellationToken cancellationToken);

        Task<List<Post>> GetTrendAsync(int page, int pageSize);
        Task<List<Post>> GetTrendAsync(int page, int pageSize, CancellationToken cancellationToken);

        Task<List<Comment>> GetCommentAsync(Post post, int page, int pageSize);
        Task<List<Comment>> GetCommentAsync(Post post, int page, int pageSize, CancellationToken cancellationToken);
    }
}
