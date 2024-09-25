namespace SpinoHackathon.ProfileServer.Models.RequestModel
{
    public class ProfileCreateModel
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string Bio { get; set; }
        public string IconUrl { get; set; }
    }
}
