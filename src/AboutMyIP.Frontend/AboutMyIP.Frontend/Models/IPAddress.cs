using System.Text.Json.Serialization;

namespace AboutMyIP.Frontend.Models
{
    public class IPAddress
    {
        [JsonPropertyName("ip")]
        public string IP { get; set; }
    }
}
