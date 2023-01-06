namespace ScoreGathering.Models;

public class Score
{
    public string PlayerId { get; set; }
    public string PlayerName { get; set; }
    public string PlayerAvatar { get; set; }
    public string MapId { get; set; }
    public float MapScore { get; set; }
    public string MapName { get; set; }
    public string MapperName { get; set; }

}