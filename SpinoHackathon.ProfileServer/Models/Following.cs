namespace SpinoHackathon.ProfileServer.Models
{
    public class Following
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Type { get; } = "Following";
        public string FollowingName { get; set; }
        public string FollowingDisplayName { get; set; }
        public string IconUrl { get; set; }
    }
}
