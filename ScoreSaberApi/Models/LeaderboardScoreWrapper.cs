using System.Text.Json.Serialization;

namespace ScoreSaberApi.Models;

public class LeaderboardScoreWrapper
{
    [JsonPropertyName("scores")]
    public List<Score> Scores { get; set; }
    
    [JsonPropertyName("metadata")]
    public MetaData MetaData { get; set; }
}