using AboutMyIP.Frontend.Models;

namespace AboutMyIP.Frontend.Services
{
    public interface IApiClientService
    {
        Task<string> GetUserIPAsync();

        Task<AboutMyIPResponse> GetIPInfo(string ip);
    }
}
