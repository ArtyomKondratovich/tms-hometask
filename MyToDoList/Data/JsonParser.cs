using System.Text.Encodings.Web;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text.Unicode;

namespace MyToDoList.Data
{
    internal class JsonParser
    {
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("creation")]
        public string? Date { get; set; }

        [JsonPropertyName("completed")]
        public bool IsCompleted { get; set; }

        public static JsonSerializerOptions options = new()
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            WriteIndented = true,
            PropertyNameCaseInsensitive = true
        };

        public JsonParser() { }

        public JsonParser(string? description, string? date, bool isCompleted)
        {
            Description = description;
            Date = date;
            IsCompleted = isCompleted;
        }
    }
}
