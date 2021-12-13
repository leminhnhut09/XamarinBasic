
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BlogApp.Models
{
    public class Photo
    {
        [JsonPropertyName("albumId")]
        public int AlbumId { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("thumbnailUrl")]
       // [JsonConverter(typeof(ThumbnailUrlConverter))]
        public string ThumbnailUrl { get; set; }

        public Photo()
        {

        }
        public Photo(int albumId, string title, string thumb)
        {
            AlbumId = albumId;
            Title = title;
            ThumbnailUrl = thumb;
        }
    }

    public class ThumbnailUrlConverter : JsonConverter<string>
    {
        public override bool HandleNull => true;
        public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.GetString() ?? "No url";
        }

        public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value ?? "No Url");
        }
    }
}
