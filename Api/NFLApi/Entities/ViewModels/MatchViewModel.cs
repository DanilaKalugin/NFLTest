using Entities.Tables;

namespace Entities.ViewModels;

public class MatchViewModel
{
    public int MatchId { get; set; }
    public TeamInfoViewModel AwayTeam { get; set; }
    public short AwayTeamScore { get; set; }
    public TeamInfoViewModel HomeTeam { get; set; }
    public short HomeTeamScore { get; set; }
    public byte OvertimesCount { get; set; }
    public DateTime MatchDate { get; set; }
    public Stadium MatchStadium { get; set; }
    public bool MatchEnded { get; set; }
    public string MatchLength
    {
        get
        {
            if (MatchEnded)
            {
                return OvertimesCount > 0 ? $"Final/{OvertimesCount}OT" : "Final";
            }

            return "";
        }
    }

    public MatchViewModel(Match match, MatchResult matchResult): this(match)
    {
        AwayTeamScore = matchResult.AwayTeamScore;
        HomeTeamScore = matchResult.HomeTeamScore;
        OvertimesCount = matchResult.OvertimesCount;
        MatchEnded = true;
    }

    public MatchViewModel(Match match)
    {
        MatchId = match.MatchId;
        MatchDate = match.MatchDate;
        AwayTeam = new TeamInfoViewModel(match.AwayTeam);
        HomeTeam = new TeamInfoViewModel(match.HomeTeam);
        MatchStadium = match.Stadium;
        MatchEnded = false;
    }
}