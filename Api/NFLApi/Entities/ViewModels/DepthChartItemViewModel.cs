using Entities.Tables;

namespace Entities.ViewModels;

public class DepthChartItemViewModel
{
    public string Role { get; set; }
    public string Position { get; set; }
    public List<PlayerInTeam> Players { get; set; }

    public DepthChartItemViewModel(string role, string position, List<PlayerInTeam> players)
    {
        Role = role;
        Position = position;
        Players = players;
    }
}