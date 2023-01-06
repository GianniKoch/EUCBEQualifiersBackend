using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using ScoreSaberApi.Interfaces;
using ScoreSaberApi.Models;

namespace ScoreSaberApi.Services;

public class ScoreSaberApiService : IScoreSaberApiService
{
    private readonly ILogger<ScoreSaberApiService> _logger;
    private readonly HttpClient _httpClient;

    public ScoreSaberApiService(ILogger<ScoreSaberApiService> logger, HttpClient httpClient)
    {
        _logger = logger;
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Score>> GetLeaderboardScoresPaged(string leaderboardId,
        uint pageCount, CancellationToken cancellationToken = default)
    {
        uint pagesReturned = 0;
        var scores = new List<Score>();
        do
        {
            var playerScoresWrapper = await GetLeaderboardScores(leaderboardId, ++pagesReturned,
                cancellationToken);
            if (playerScoresWrapper == null)
            {
                _logger.LogWarning("Something went wrong :c");
                break;
            }

            scores.AddRange(playerScoresWrapper.Scores);
        } while (pagesReturned < pageCount);
        
        return scores;
    }

    public async Task<LeaderboardScoreWrapper?> GetLeaderboardScores(string leaderboardId, uint page, CancellationToken cancellationToken = default)
    {
        var urlBuilder = new StringBuilder($"leaderboard/by-id/{leaderboardId}/scores?countries=BE%2CNL&page={page}");

        var url = urlBuilder.ToString();

        return await GetAsync<LeaderboardScoreWrapper>(url, cancellationToken);
    }
    
    public async Task<Leaderboard?> GetLeaderboard(string leaderboardId, CancellationToken cancellationToken = default)
    {
        var urlBuilder = new StringBuilder($"leaderboard/by-id/{leaderboardId}/info");

        var url = urlBuilder.ToString();

        return await GetAsync<Leaderboard>(url, cancellationToken);
    }

    private async Task<T?> GetAsync<T>(string url, CancellationToken cancellationToken = default)
    {
        using var response = await _httpClient.GetAsync(url,
            HttpCompletionOption.ResponseHeadersRead, cancellationToken);

        if (!response.IsSuccessStatusCode) return default;
        
        try
        {
            return await response.Content
                .ReadFromJsonAsync<T>(cancellationToken: cancellationToken).ConfigureAwait(false);
        }
        catch (NotSupportedException) // When content type is not valid
        {
            _logger.LogError("The content type is not supported");
        }
        catch (JsonException ex) // Invalid JSON
        {
            _logger.LogError(ex, "Invalid JSON for call: {Url}", url);
        }

        return default;
    }
}