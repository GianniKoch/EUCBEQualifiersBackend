using Microsoft.Extensions.DependencyInjection;
using ScoreGathering.Interfaces;
using ScoreGathering.Services;
using ScoreSaberApi.Extensions;

namespace ScoreGathering.Extensions;

public static class ScoreGatheringMiddlewareExtensions
{
    public static void AddScoreGathering(this IServiceCollection services, string appName, Version version,
        string scoreSaberApiUrl)
    {
        services.AddScoreSaberApi(appName, version, scoreSaberApiUrl);
        services.AddSingleton<IScoreGatheringService, ScoreGatheringService>();
    }
}