using Entities.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace NFL.DAO;

public class TeamsDAO
{
    public async Task<FullTeamInfoViewModel?> GetTeam(string teamAbbreviation)
    {
        await using var db = new NFLApplicationContext();

        var team = await db.Teams!.Where(t => t.TeamAbbreviation == teamAbbreviation)
            .Include(t => t.Conference)
            .Include(t => t.Stadium)
            .ThenInclude(s => s.StadiumLocation)
            .Include(t => t.Colors.Where(tc => tc.TeamAbbreviation == teamAbbreviation).OrderBy(tc => tc.ColorNumber))
            .Include(t => t.SocialNetworkAccounts)
            .ThenInclude(sna => sna.AccountType)
            .FirstOrDefaultAsync();

        var record = await db.TeamStandings.FirstOrDefaultAsync(s => s.TeamAbbreviation == teamAbbreviation);

        return new FullTeamInfoViewModel(team, record);
    }

    public async Task<List<ShortTeamInfoViewModel>> GetTeamsFromState(string stateCode)
    {
        await using var db = new NFLApplicationContext();
        var teams = await db.Teams!.Include(t => t.Stadium)
            .ThenInclude(s => s.StadiumLocation)
            .Include(t => t.Colors.OrderBy(tc => tc.ColorNumber))
            .Where(t => t.Stadium.StadiumLocation.CityStateId == stateCode)
            .ToListAsync()
            .ConfigureAwait(false);

        return teams.Select(t => new ShortTeamInfoViewModel(t)).ToList();
    }

    public async Task<List<ShortTeamInfoViewModel>> GetTeamsFromConferenceAsync(byte division)
    {
        await using var db = new NFLApplicationContext();
        var teams = await db.Teams!.Where(t => t.ConferenceId == division)
            .Include(t => t.Colors.OrderBy(tc => tc.ColorNumber))
            .ToListAsync();

        return teams.Select(t => new ShortTeamInfoViewModel(t)).ToList();
    }
}