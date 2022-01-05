using Newtonsoft.Json;
namespace BlogApp.Models
{
    public class FacebookProfile
    {
        public string Email { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        public Picture Picture { get; set; }
    }
    public class NetworkAuthData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Logo { get; set; }

        public string Picture { get; set; }

        public string Background { get; set; }

        public string Foreground { get; set; }
    }
    public class Picture
    {
        public Data Data { get; set; }
    }

    public class Data
    {
        [JsonProperty("is_silhouette")]
        public bool Is_Silhouette { get; set; }
        public int Height { get; set; }
        public string Url { get; set; }
        public int Width { get; set; }
    }
}
