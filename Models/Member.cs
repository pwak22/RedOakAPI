using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace RedOakAPI.Models
{
    public class Member
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("firstname")]
        public string First_Name { get; set; }

        [JsonPropertyName("lastname")]
        public string Last_Name { get; set; }

        [JsonPropertyName("middle")]
        public string? Middle_Name { get; set; }

        [JsonPropertyName("age")]
        public int Age { get; set; }

        [JsonPropertyName("birthdate")]
        public DateTime Birthdate { get; set; }

        [JsonPropertyName("sex")]
        public string Sex { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

    }
}
