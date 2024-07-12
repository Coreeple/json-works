using System.Text.Json.Serialization;

namespace Model
{
    public class Address(string street, string suite, string city, string zipcode, Geo geo)
    {
        [JsonPropertyName("street")]
        public string Street { get; set; } = street;

        [JsonPropertyName("suite")]
        public string Suite { get; set; } = suite;

        [JsonPropertyName("city")]
        public string City { get; set; } = city;

        [JsonPropertyName("zipcode")]
        public string Zipcode { get; set; } = zipcode;

        [JsonPropertyName("geo")]
        public Geo Geo { get; set; } = geo;
    }
}
