namespace AboutMyIP.Models
{
    public class AboutMyIPResponse
    {
        public string Ip { get; set; }

        public ConnectionInfo ConnectionInfo { get; set; }

        public ISPInfo ISPInfo { get; set; }

        public LocationInfo LocationInfo { get; set; }
    }

    public class ConnectionInfo
    {
        public bool IsBehindVpn { get; set; }

        public bool IsBehindProxy { get; set; }

        public bool IsBehindTor { get; set; }
    }

    public class ISPInfo
    {
        public string Network { get; set; }
    }

    public class LocationInfo
    {
        public string City { get; set; }

        public string Region { get; set; }

        public string Country { get; set; }

        public string Continent { get; set; }

        public string RegionCode { get; set; }

        public string CountryCode { get; set; }

        public string ContinentCode { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string TimeZone { get; set; }

        public string LocaleCode { get; set; }

        public string MetroCode { get; set; }

        public bool IsEuropeanUnion { get; set; }
    }
}