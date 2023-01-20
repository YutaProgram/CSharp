using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace JSONSampleConsoleApp
{
    internal class Ramen
    {
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("price")] public int Price { get; set; }
        [JsonPropertyName("tuika")] public List<string> Tuika { get; set; }
        [JsonPropertyName("ramen_info")] public Ramen_Info Info { get; set; }
    }
}
