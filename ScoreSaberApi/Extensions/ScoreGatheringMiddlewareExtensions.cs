using System.Net;
using Microsoft.Extensions.DependencyInjection;
using ScoreSaberApi.Interfaces;
using ScoreSaberApi.Services;

namespace ScoreSaberApi.Extensions;

public static class ScoreSaberApiMiddlewareExtensions
{
    public static void AddScoreSaberApi(this IServiceCollection services, string appName, Version version,
        string scoreSaberApiUrl)
    {
        services.AddSingleton<IScoreSaberApiService, ScoreSaberApiService>();
        services.AddHttpClient<IScoreSaberApiService, ScoreSaberApiService>(client =>
        {
            client.BaseAddress = new Uri(scoreSaberApiUrl, UriKind.Absolute);
            client.Timeout = TimeSpan.FromSeconds(30);
            client.DefaultRequestVersion = HttpVersion.Version20;
            client.DefaultRequestHeaders.Add("User-Agent", $"{appName}/{version.ToString(3)}");
        });
    }
}