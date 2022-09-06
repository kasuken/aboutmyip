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
            var client = _httpClientFactory.CreateClient("RapidAPI");
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{client.BaseAddress.AbsoluteUri}/{ip}"),
                Headers =
                {
                    { "X-RapidAPI-Host", "about-my-ip.p.rapidapi.com" },
                    { "X-RapidAPI-Key", _configuration["rapidAPIKey"] }
                },
            };

            using var response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AboutMyIPResponse>(body);
        }

        public async Task<IPAddress> GetUserIPAsync()
        {
            var client = _httpClientFactory.CreateClient("IP");
            return await client.GetFromJsonAsync<IPAddress>("?format=json");
        }
    }
}
