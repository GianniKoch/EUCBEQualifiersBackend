using ScoreGathering.Models;

namespace ScoreGathering.Interfaces;

public interface IScoreGatheringService
{
    Task<List<Score>> GetScores();
}