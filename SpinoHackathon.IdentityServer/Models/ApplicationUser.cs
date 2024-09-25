using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SpinoHackathon.IdentityServer.Models.Arguments;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace SpinoHackathon.IdentityServer.Models
{
    public class ApplicationUser
    {
        [Key]
        [JsonProperty("id")]
        public string Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
    }
}
