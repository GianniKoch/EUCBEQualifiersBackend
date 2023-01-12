using ScoreGathering.Interfaces;
using ScoreSaberApi.Interfaces;
using Score = ScoreGathering.Models.Score;

namespace ScoreGathering.Services;

public class ScoreGatheringService : IScoreGatheringService
{
    private readonly IScoreSaberApiService _scoreSaberApiService;

    private readonly string[] _playerIds =
    {
        "76561198303746219", "76561199070301810", "76561199124634617", "2362658747090970", "76561198213166340",
        "76561198202676664", "76561198170634587", "76561198119521451", "76561198178432854", "76561198980971526",
        "76561198885143559", "76561198439336323", "76561198004212463", "76561198033792649", "76561198055050272",
        "76561199206204757"
    };

    private readonly string[] _leaderboardIds =
    {
        "537242", "372250", "463089", "396311", "415283", "380003", "368793", "421816"
    };

    public ScoreGatheringService(IScoreSaberApiService scoreSaberApiService)
    {
        _scoreSaberApiService = scoreSaberApiService;
    }

    public async Task<List<Score>> GetScores()
    {
        var scores = new List<Score>();
        foreach (var leaderboardId in _leaderboardIds)
        {
            var leaderboard = await _scoreSaberApiService.GetLeaderboard(leaderboardId);
            var playerScores = await _scoreSaberApiService.GetLeaderboardScoresPaged(leaderboardId, 4);

            scores.AddRange(from score in playerScores
                where _playerIds.Contains(score.LeaderboardPlayerInfo.Id)
                select new Score
                {
                    PlayerId = score.LeaderboardPlayerInfo.Id, PlayerName = score.LeaderboardPlayerInfo.Name,
                    PlayerAvatar = score.LeaderboardPlayerInfo.ProfilePicture, MapId = leaderboardId,
                    MapScore = (float)score.BaseScore / leaderboard.MaxScore,
                    MapName = $"{leaderboard.SongName} {leaderboard.SongSubName} - {leaderboard.SongAuthorName}",
                    MapperName = leaderboard.LevelAuthorName
                });
        }

        return scores;
    }
}