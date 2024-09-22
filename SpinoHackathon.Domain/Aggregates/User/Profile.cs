using System.ComponentModel.DataAnnotations;

namespace SpinoHackathon.Domain.Aggregates.User
{
    public class Profile : Entity
    {
        [Required]
        public string IdentityGuid { get; private set; }
        [Required]
        public string DisplayName { get; private set; }

        public string Bio { get; private set; }
        [Url]
        public string IconUrl { get; private set; }

        private List<Profile> _following;
        public IReadOnlyCollection<Profile> Following => _following?.AsReadOnly();

        private List<Profile> _followers;
        public IReadOnlyCollection<Profile> Followers => _followers?.AsReadOnly();

        protected Profile()
        {
            _following = new List<Profile>();
            _followers = new List<Profile>();
        }

        public Profile(string identityGuid, string displayName, string? bio, string? iconUrl) : this()
        {
            if (string.IsNullOrWhiteSpace(identityGuid))
            {
                throw new ArgumentNullException(nameof(identityGuid));
            }

            if (string.IsNullOrWhiteSpace(displayName)) 
            {
                throw new ArgumentNullException(nameof(displayName));
            }

            IdentityGuid = identityGuid;
            DisplayName = displayName;
            Bio = bio ?? string.Empty;
            IconUrl = iconUrl ?? string.Empty;
        }

        public void Follow(Profile profile)
        {
            ArgumentNullException.ThrowIfNull(profile);

            if (_following.Contains(profile))
            {
                return;
            }

            _following.Add(profile);
            profile.AddFollower(this);
        }

        public void Unfollow(Profile profile)
        {
            ArgumentNullException.ThrowIfNull(profile);

            if (!_following.Contains(profile))
            {
                return;
            }

            _following.Remove(profile);
            profile.RemoveFollower(this);
        }

        private void AddFollower(Profile profile)
        {
            ArgumentNullException.ThrowIfNull(profile);

            if (_followers.Contains(profile))
            {
                return;
            }

            _followers.Add(profile);
        }

        private void RemoveFollower(Profile profile)
        {
            ArgumentNullException.ThrowIfNull(profile);

            if (!_followers.Contains(profile))
            {
                return;
            }

            _followers.Remove(profile);
        }

        public void UpdateBio(string bio)
        {
            ArgumentNullException.ThrowIfNull(bio);

            Bio = bio;
        }

        public void UpdateIconUrl(string iconUrl)
        {
            ArgumentNullException.ThrowIfNull(iconUrl);

            IconUrl = iconUrl;
        }

        public void UpdateDisplayName(string displayName)
        {
            ArgumentNullException.ThrowIfNull(displayName);

            if (string.IsNullOrWhiteSpace(displayName))
            {
                throw new ArgumentNullException(nameof(displayName));
            }

            DisplayName = displayName;
        }
    }
}
