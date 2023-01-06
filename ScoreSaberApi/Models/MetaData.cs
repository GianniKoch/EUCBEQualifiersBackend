using System.Text.Json.Serialization;

namespace ScoreSaberApi.Models;

public class MetaData
{
    [JsonPropertyName("total")]
    public int Total { get; set; }
    [JsonPropertyName("page")]
    public int Page { get; set; }
    [JsonPropertyName("itemsPerPage")]
    public int ItemsPerPage { get; set; }
}