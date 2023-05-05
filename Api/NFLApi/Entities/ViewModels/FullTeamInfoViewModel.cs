using Entities.Tables;
using Entities.Views;

namespace Entities.ViewModels;

public class FullTeamInfoViewModel
{
    public string TeamAbbreviation { get; set; }
    public string TeamRegion { get; set; }
    public string TeamName { get; set; }
    public Stadium Stadium { get; set; }
    public TeamMainInfo MainInfo { get; set; }
    public List<SocialNetworkAccount> SocialNetworkAccounts { get; set; }

    public FullTeamInfoViewModel(Team? team, TeamStandings? teamRecord)
    {
        TeamAbbreviation = team!.TeamAbbreviation;
        TeamRegion = team.TeamRegion;
        TeamName = team.TeamName;
        Stadium = team.Stadium;
        MainInfo = new TeamMainInfo(team, teamRecord!);
        SocialNetworkAccounts = team.SocialNetworkAccounts;
    }
}