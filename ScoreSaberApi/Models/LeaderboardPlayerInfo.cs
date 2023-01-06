using System.Text.Json.Serialization;

namespace ScoreSaberApi.Models;

public class LeaderboardPlayerInfo
{
    /*
     * "id": "string",
          "name": "string",
          "profilePicture": "string",
          "country": "string",
          "permissions": 0,
          "role": "string"
     */

    [JsonPropertyName("id")] public string Id { get; set; }

    [JsonPropertyName("name")] public string Name { get; set; }

    [JsonPropertyName("profilePicture")] public string ProfilePicture { get; set; }
}