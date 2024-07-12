using System.Text.Json.Serialization;

namespace Model
{
    public class Geo(string lat, string lng)
    {
        [JsonPropertyName("lat")]
        public string Lat { get; set; } = lat;

        [JsonPropertyName("lng")]
        public string Lng { get; set; } = lng;
    }
}
