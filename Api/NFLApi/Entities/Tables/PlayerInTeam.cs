namespace Entities.Tables;

public class PlayerInTeam
{
    public int PlayerInTeamId { get; set; }
    public Team Team { get; set; }
    public string TeamAbbreviation { get; set; }
    public string PlayerRole { get; set; }
    public string PlayerPosition { get; set; }
    public int PlayerJerseyNumber { get; set; }
    public string PlayerName { get; set; }
    public string PlayerStatus { get; set; }
}