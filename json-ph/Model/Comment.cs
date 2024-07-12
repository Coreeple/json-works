using System.Text.Json.Serialization;

namespace Model
{
    public class Comment(int postId, int id, string name, string email, string body)
    {
        [JsonPropertyName("postId")]
        public int PostId { get; set; } = postId;

        [JsonPropertyName("id")]
        public int Id { get; set; } = id;

        [JsonPropertyName("name")]
        public string Name { get; set; } = name;

        [JsonPropertyName("email")]
        public string Email { get; set; } = email;

        [JsonPropertyName("body")]
        public string Body { get; set; } = body;
    }
}
