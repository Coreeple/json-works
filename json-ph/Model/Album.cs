using System.Text.Json.Serialization;

namespace Model
{
    public class Album(int userId, int id, string title)
    {
        [JsonPropertyName("userId")]
        public int UserId { get; set; } = userId;

        [JsonPropertyName("id")]
        public int Id { get; set; } = id;

        [JsonPropertyName("title")]
        public string Title { get; set; } = title;
    }
}
