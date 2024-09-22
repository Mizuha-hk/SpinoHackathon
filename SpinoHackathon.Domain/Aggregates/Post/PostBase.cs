using System.ComponentModel.DataAnnotations;

namespace SpinoHackathon.Domain.Aggregates.Post
{
    public abstract class PostBase : Entity, IAggregateRoot
    {
        [Required]
        public Profile Author { get; private set; }
        [Required]
        public string Content { get; private set; }

        public string?[] AssetUrls { get; private set; } = new string?[4];

        public DateTime CreatedAt { get; private set; }

        public int LikeCount => _likeUsers.Count;

        private List<Profile> _likeUsers;
        public IReadOnlyCollection<Profile> LikeUsers => _likeUsers?.AsReadOnly();

        protected PostBase()
        {
            _likeUsers = new List<Profile>();
        }

        public PostBase(Profile author, string content, string?[] assetUrls) : this()
        {
            ArgumentNullException.ThrowIfNull(author);
            ArgumentNullException.ThrowIfNull(content);

            Author = author;
            Content = content;
            AssetUrls = assetUrls;
            CreatedAt = DateTime.UtcNow;
        }

        public virtual void Like(Profile profile)
        {
            ArgumentNullException.ThrowIfNull(profile);

            if (_likeUsers.Contains(profile))
            {
                return;
            }

            _likeUsers.Add(profile);
        }

        public virtual void Unlike(Profile profile)
        {
            ArgumentNullException.ThrowIfNull(profile);

            if (!_likeUsers.Contains(profile))
            {
                return;
            }

            _likeUsers.Remove(profile);
        }
    }
}
