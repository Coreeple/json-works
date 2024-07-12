using System.Text.Json.Serialization;

namespace Model
{
    public class Post(int userId, int id, string title, string body)
    {
        [JsonPropertyName("userId")]
        public int UserId { get; set; } = userId;

        [JsonPropertyName("id")]
        public int Id { get; set; } = id;

        [JsonPropertyName("title")]
        public string Title { get; set; } = title;

        [JsonPropertyName("body")]
        public string Body { get; set; } = body;
    }
}
