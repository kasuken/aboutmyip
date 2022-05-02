using AboutMyIP.Models;
using System.Net.Http.Json;

namespace AboutMyIP.Services
{
    public class AboutMyIPService : IAboutMyIPService
    {
        public async Task<AboutMyIPResponse> GetIPInfo(string ip)
        {
            var httpClient = new HttpClient();
            var result = await httpClient.GetFromJsonAsync($"https://vpnapi.io/api/{ip}?key={_configuration["VPNAPI_KEY"]}");



        }
    }
}
