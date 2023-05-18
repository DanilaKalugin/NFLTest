using Entities.Tables;

namespace Entities.ViewModels;

public class ShortTeamInfoViewModel: TeamInfoViewModel
{
    public string TeamColor { get; set; }

    public ShortTeamInfoViewModel(Team team): base (team)
    {
        TeamAbbreviation = team.TeamAbbreviation;
        TeamRegion = team.TeamRegion;
        TeamName = team.TeamName;
        TeamColor = team.Colors[0].Color;
    }
}