using System.Text.Json.Serialization;

namespace Model
{
    public class User(
        int id, string name, string username, string email, Address address,
        string phone, string website, Company company)
    {
        [JsonPropertyName("id")]
        public int Id { get; set; } = id;

        [JsonPropertyName("name")]
        public string Name { get; set; } = name;

        [JsonPropertyName("username")]
        public string Username { get; set; } = username;

        [JsonPropertyName("email")]
        public string Email { get; set; } = email;

        [JsonPropertyName("address")]
        public Address Address { get; set; } = address;

        [JsonPropertyName("phone")]
        public string Phone { get; set; } = phone;

        [JsonPropertyName("website")]
        public string Website { get; set; } = website;

        [JsonPropertyName("company")]
        public Company Company { get; set; } = company;

    }
}
