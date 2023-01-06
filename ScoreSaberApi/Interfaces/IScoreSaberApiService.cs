using ScoreSaberApi.Models;

namespace ScoreSaberApi.Interfaces;

public interface IScoreSaberApiService
{
    Task<IEnumerable<Score>> GetLeaderboardScoresPaged(string leaderboardId, uint pageCount, CancellationToken cancellationToken =
        default);

    Task<LeaderboardScoreWrapper?> GetLeaderboardScores(string leaderboardId, uint page,
        CancellationToken cancellationToken = default);

    Task<Leaderboard?> GetLeaderboard(string leaderboardId, CancellationToken cancellationToken = default);
}