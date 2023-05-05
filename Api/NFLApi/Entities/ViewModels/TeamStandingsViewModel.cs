using System.Text.Json.Serialization;
using Entities.Tables;
using Entities.Views;

namespace Entities.ViewModels;

public class TeamStandingsViewModel
{
    public string TeamAbbreviation { get; set; }
    public string TeamRegion { get; set; }
    public string TeamName { get; set; }
    public string TeamColor { get; set; }
    public short? TeamRank { get; set; }
    public int TeamWins { get; set; }
    public int TeamLosses { get; set; }
    [JsonIgnore]
    public byte TeamConference { get; set; }

    public TeamStandingsViewModel(Team team, TeamStandings teamRecord)
    {
        TeamAbbreviation = team.TeamAbbreviation;
        TeamRegion = team.TeamRegion;
        TeamName = team.TeamName;
        TeamColor = team.Colors[0].Color;
        TeamRank = team.TeamRank;
        TeamWins = teamRecord.W;
        TeamLosses = teamRecord.L;
        TeamConference = team.ConferenceId;
    }
}