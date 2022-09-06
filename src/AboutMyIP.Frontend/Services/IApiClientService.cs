using AboutMyIP.Frontend.Models;

namespace AboutMyIP.Frontend.Services
{
    public interface IApiClientService
    {
        Task<IPAddress> GetUserIPAsync();

        Task<AboutMyIPResponse> GetIPInfo(string ip);
    }
}
