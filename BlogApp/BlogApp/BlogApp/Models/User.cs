using System.Text.Json.Serialization;

namespace BlogApp.Models
{
    public class User
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("username")]
        public string UserName { get; set; }

        public User()
        {

        }
        public User(int id, string name, string userName)
        {
            Id = id;
            Name = name;
            UserName = userName; 
        }
    }
}
