using System.Text.Json.Serialization;

namespace Model
{
    public class Photo(int albumId, int id, string title, string url, string thumbnailUrl)
    {
        [JsonPropertyName("albumId")]
        public int AlbumId { get; set; } = albumId;

        [JsonPropertyName("id")]
        public int Id { get; set; } = id;

        [JsonPropertyName("title")]
        public string Title { get; set; } = title;

        [JsonPropertyName("url")]
        public string Url { get; set; } = url;

        [JsonPropertyName("thumbnailUrl")]
        public string ThumbnailUrl { get; set; } = thumbnailUrl;
    }


}
