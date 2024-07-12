using System.Text.Json.Serialization;

namespace Model
{
    public class Company(string name, string catchPhrase, string bs)
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = name;

        [JsonPropertyName("catchPhrase")]
        public string CatchPhrase { get; set; } = catchPhrase;

        [JsonPropertyName("bs")]
        public string Bs { get; set; } = bs;
    }
}
