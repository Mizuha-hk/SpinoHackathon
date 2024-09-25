using SpinoHackathon.ProfileServer.Models.ResponseModel;
using System.Text;
using System.Text.Json;

namespace SpinoHackathon.ProfileServer.Services
{
    public class IdentityServeHttpClient(HttpClient httpClient)
    {
        public async Task<IdResponse> GetUserIdByToken(string token)
        {
            StringContent jsonContent = new(
                JsonSerializer.Serialize(new { Token = token }),
                Encoding.UTF8,
                "application/json");

            var response = await httpClient.PostAsync("/authentications/validate", jsonContent);

            return await response.Content.ReadFromJsonAsync<IdResponse>();
        }
    }
}
