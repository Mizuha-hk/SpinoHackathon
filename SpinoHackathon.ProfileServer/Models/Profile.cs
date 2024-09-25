namespace SpinoHackathon.ProfileServer.Models
{
    public class Profile
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Type { get; } = "Profile";
        public string DisplayName { get; set; }
        public string Bio { get; set; }
        public string IconUrl { get; set; }
        public int Following { get; set; } = 0;
        public int Followers { get; set; } = 0;
    }
}
