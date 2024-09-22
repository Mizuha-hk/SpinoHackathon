using System.ComponentModel.DataAnnotations;

namespace SpinoHackathon.Domain.Aggregates.User
{
    public class User : Entity, IAggregateRoot
    {
        [Required]
        public string IdentityGuid { get; private set; }
        [Required]
        public string Name { get; private set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public Profile Profile { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public User(string identityGuid, string name, string email, string password, Profile profile)
        {
            if (string.IsNullOrWhiteSpace(identityGuid))
            {
                throw new ArgumentNullException(nameof(identityGuid));
            }

            if (string.IsNullOrWhiteSpace(name)) 
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (string.IsNullOrWhiteSpace(email)) 
            {
                throw new ArgumentNullException(nameof(email));
            }

            if (string.IsNullOrWhiteSpace(password)) 
            {
                throw new ArgumentNullException(nameof(password));
            }

            ArgumentNullException.ThrowIfNull(profile);

            IdentityGuid = identityGuid;
            Name = name;
            Email = email;
            Password = password;
            Profile = profile;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
