using System.Text.Json.Serialization;

public class LocationInfo
{
    [JsonPropertyName("count")]
    public int Count { get; set; }
    [JsonPropertyName("pages")]
    public int Pages { get; set; }
    [JsonPropertyName("next")]
    public string Next { get; set; }
    [JsonPropertyName("prev")]
    public string Prev { get; set; }
}