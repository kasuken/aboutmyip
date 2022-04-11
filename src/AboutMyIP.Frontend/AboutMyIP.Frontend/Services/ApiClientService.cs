using AboutMyIP.Frontend.Models;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace AboutMyIP.Frontend.Services
{
    public class ApiClientService : IApiClientService
    {

        private readonly IHttpClientFactory _httpClientFactory;

        private readonly IConfiguration _configuration;

        public ApiClientService(IHttpClientFactory httpClientfactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientfactory;
            _configuration = configuration;
        }

        public async Task<AboutMyIPResponse> GetIPInfo(string ip)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://about-my-ip.p.rapidapi.com/getipinfo/{ip}"),
                Headers =
                {
                    { "X-RapidAPI-Host", "about-my-ip.p.rapidapi.com" },
                    { "X-RapidAPI-Key", _configuration["rapidAPIKey"] },
                },
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<AboutMyIPResponse>(body);
                return result;
            }
        }

        public async Task<IPAddress> GetUserIPAsync()
        {
            var client = _httpClientFactory.CreateClient("IP");
            return await client.GetFromJsonAsync<IPAddress>("/");
        }

    }
}
