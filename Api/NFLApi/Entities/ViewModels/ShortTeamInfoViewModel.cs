using Entities.Tables;

namespace Entities.ViewModels;

public class ShortTeamInfoViewModel
{
    public string TeamAbbreviation { get; set; }
    public string TeamRegion { get; set; }
    public string TeamName { get; set; }
    public string TeamColor { get; set; }

    public ShortTeamInfoViewModel(Team team)
    {
        TeamAbbreviation = team.TeamAbbreviation;
        TeamRegion = team.TeamRegion;
        TeamName = team.TeamName;
        TeamColor = team.Colors[0].Color;
    }
}