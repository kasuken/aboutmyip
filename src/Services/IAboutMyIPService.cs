using AboutMyIP.Models;

namespace AboutMyIP.Services
{
    public interface IAboutMyIPService
    {

        Task<AboutMyIPResponse> GetIPInfo(string ip);

    }
}
