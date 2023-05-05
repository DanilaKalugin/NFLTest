using Entities.Tables;
using Entities.Views;

namespace Entities.ViewModels
{
    public class TeamMainInfo
    {
        public string Conference { get; set; }
        public string Coach { get; set; }
        public short? TeamRank { get; set; }
        public string Location { get; set; }
        public string StadiumTitle { get; set; }
        public TeamRecordViewModel TeamRecord { get; set; }
        public List<TeamColor> Colors { get; set; }

        public TeamMainInfo(Team team, TeamStandings teamRecord)
        {
            Colors = team.Colors;
            TeamRank = team.TeamRank;
            TeamRecord = new TeamRecordViewModel(teamRecord);
            Conference = team.Conference.ConferenceName;
            Coach = team.Coach;
            Location = team.Stadium.StadiumLocation.CityLocation;
            StadiumTitle = team.Stadium.StadiumTitle;
        }
    }
}
