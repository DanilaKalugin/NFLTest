using System.Text;
using Coursework.DAL;
using Entities.Tables;

namespace Coursework.BLL;

public class MatchesBL
{
    private readonly MatchesDAO _matchesDAO;

    public MatchesBL(MatchesDAO matchesDao)
    {
        _matchesDAO = matchesDao;
    }
    
    public async Task<string?> GetMessageAboutLastTeamMatch(string team)
    {
        var lastMatch = await _matchesDAO.GetLastMatchForThisTeamAsync(team).ConfigureAwait(false);

        return lastMatch == null ? null : CreateMessageAboutMatch(lastMatch);
    }

    private string CreateMessageAboutMatch(MatchResult matchResult)
    {
        var sb = new StringBuilder();

        sb.Append(matchResult.MatchWinner.TeamRegion);
        sb.Append(" beat ");
        sb.Append(matchResult.MatchLoser.TeamRegion);
        sb.Append(", ");

        sb.Append(Math.Max(matchResult.AwayTeamScore, matchResult.HomeTeamScore));
        sb.Append('-');
        sb.Append(Math.Min(matchResult.AwayTeamScore, matchResult.HomeTeamScore));

        if (matchResult.OvertimesCount <= 0) return sb.ToString();

        sb.Append(" (");
        if (matchResult.OvertimesCount > 1) sb.Append(matchResult.OvertimesCount);
        sb.Append("OT)");

        return sb.ToString();
    }
}