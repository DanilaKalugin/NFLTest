using Entities.Tables;
using Entities.Views;

namespace Entities.ViewModels;

public class FullTeamInfoViewModel: TeamInfoViewModel
{
    public Stadium Stadium { get; set; }
    public TeamMainInfo MainInfo { get; set; }
    public List<SocialNetworkAccount> SocialNetworkAccounts { get; set; }

    public FullTeamInfoViewModel(Team? team, TeamStandings? teamRecord): base (team)
    {
        Stadium = team.Stadium;
        MainInfo = new TeamMainInfo(team, teamRecord!);
        SocialNetworkAccounts = team.SocialNetworkAccounts;
    }
}