namespace SpinoHackathon.ProfileServer.Models
{
    public class Follower
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Type { get; } = "Follower";
        public string FollowerName { get; set; }
        public string FollowerDisplayName { get; set; }
        public string IconUrl { get; set; }
    }
}
