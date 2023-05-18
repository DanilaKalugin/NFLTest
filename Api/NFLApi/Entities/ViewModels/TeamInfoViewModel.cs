using Entities.Tables;

namespace Entities.ViewModels;

public class TeamInfoViewModel
{
    public string TeamAbbreviation { get; set; }
    public string TeamRegion { get; set; }
    public string TeamName { get; set; }

    public TeamInfoViewModel(Team team)
    {
        TeamAbbreviation = team!.TeamAbbreviation;
        TeamRegion = team.TeamRegion;
        TeamName = team.TeamName;
    }
}