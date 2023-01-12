using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using ScoreGathering.Interfaces;

namespace BackendApi.Controllers;

[ApiController]
[Route("[controller]")]
public class QualifierController : ControllerBase
{
    private readonly IScoreGatheringService _scoreGatheringService;

    public QualifierController(IScoreGatheringService scoreGatheringService)
    {
        _scoreGatheringService = scoreGatheringService;
    }

    [HttpGet]
    [OutputCache]
    public async Task<IActionResult> Standings()
    {
        return Ok(await _scoreGatheringService.GetScores());
    }
}