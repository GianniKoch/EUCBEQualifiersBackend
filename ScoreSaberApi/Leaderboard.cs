using System.Text.Json.Serialization;

namespace ScoreSaberApi;

public class Leaderboard
{
    [JsonPropertyName("maxScore")] public int MaxScore { get; set; }
    [JsonPropertyName("songName")] public string SongName { get; set; }
    [JsonPropertyName("songSubName")] public string SongSubName { get; set; }
    [JsonPropertyName("songAuthorName")] public string SongAuthorName { get; set; }
    [JsonPropertyName("levelAuthorName")] public string LevelAuthorName { get; set; }
}