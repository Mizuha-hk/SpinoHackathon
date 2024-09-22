namespace SpinoHackathon.Domain.Aggregates.Post
{
    public class Comment : PostBase
    {
        public Comment(Profile author, string content, string?[] assetUrls) : base(author, content, assetUrls) { }
    }
}
