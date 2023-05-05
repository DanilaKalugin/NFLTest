using Entities.Views;

namespace Entities.ViewModels;

public class TeamRecordViewModel
{
    public int TeamWins { get; set; }
    public int TeamLosses { get; set; }

    public TeamRecordViewModel(TeamStandings? teamRecord)
    {
        TeamWins = teamRecord!.W;
        TeamLosses = teamRecord.L;
    }
}