using System.Text.Json.Serialization;

namespace JSONSampleConsoleApp
{
    internal class Ramen_Info
    {
        [JsonPropertyName("men")] public string Men { get; set; }
        [JsonPropertyName("soup")] public string Soup { get; set; }

    }
}
