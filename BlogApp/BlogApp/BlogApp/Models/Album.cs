using System.Text.Json.Serialization;

namespace BlogApp.Models
{
    public class Album
    {
        [JsonPropertyName("userId")]
        public int UserId { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string TitleAlbum { get; set; }
    }
}
