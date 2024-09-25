using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace SpinoHackathon.WebApp.Extensions
{
    public static class HostingExtensions
    {
        public const string OpenIdConnectBackchannel = "OpenIdConnectBackchannel";

        public static void AddAuthenticationServices(this IHostApplicationBuilder builder)
        {
            
        }
    }
}
