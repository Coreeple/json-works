using System.Text.Json.Serialization;

namespace Model
{
    public class Todo(int userId, int id, string title, bool completed)
    {
        [JsonPropertyName("userId")]
        public int UserId { get; set; } = userId;

        [JsonPropertyName("id")]
        public int Id { get; set; } = id;

        [JsonPropertyName("title")]
        public string Title { get; set; } = title;

        [JsonPropertyName("completed")]
        public bool Completed { get; set; } = completed;
    }


}
