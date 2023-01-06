using System.Text.Json.Serialization;

namespace ScoreSaberApi.Models;

public class Score
{
    [JsonPropertyName("leaderboardPlayerInfo")]
    public LeaderboardPlayerInfo LeaderboardPlayerInfo { get; set; }

    [JsonPropertyName("baseScore")]
    public int BaseScore { get; set; }
}