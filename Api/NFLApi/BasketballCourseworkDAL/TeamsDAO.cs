using Entities.Tables;
using Entities.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Coursework.DAL;

public class TeamsDAO
{
    private readonly CourseworkApplicationContext db;

    public TeamsDAO(CourseworkApplicationContext courseworkApplicationContext)
    {
        db = courseworkApplicationContext;
    }
    public async Task<FullTeamInfoViewModel?> GetTeam(string teamAbbreviation)
    {

        var team = await db.Teams!.Where(t => t.TeamAbbreviation == teamAbbreviation)
            .Include(t => t.Conference)
            .Include(t => t.Stadium)
            .ThenInclude(s => s.StadiumLocation)
            .Include(t => t.Colors.Where(tc => tc.TeamAbbreviation == teamAbbreviation).OrderBy(tc => tc.ColorNumber))
            .Include(t => t.SocialNetworkAccounts)
            .ThenInclude(sna => sna.AccountType)
            .FirstOrDefaultAsync();

        var record = await db.TeamStandings.FirstOrDefaultAsync(s => s.TeamAbbreviation == teamAbbreviation);

        return team is null || record is null ? null : new FullTeamInfoViewModel(team, record);
    }

    public async Task<List<ShortTeamInfoViewModel>> GetTeamsFromState(string stateCode)
    {
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
        var teams = await db.Teams!.Where(t => t.ConferenceId == division)
            .Include(t => t.Colors.OrderBy(tc => tc.ColorNumber))
            .ToListAsync();

        return teams.Select(t => new ShortTeamInfoViewModel(t)).ToList();
    }

    public async Task<List<ShortTeamInfoViewModel>> GetAllTeams()
    {
        var teams = await db.Teams!
            .Include(t => t.Colors.OrderBy(tc => tc.ColorNumber))
            .ToListAsync();
        
        return teams.Select(t => new ShortTeamInfoViewModel(t)).ToList();
    }

    public async Task<List<MatchViewModel>> GetResultsOfMatchesForThisTeam(string teamAbbreviation)
    {
        var results = await db.Matches.Include(m => m.MatchResult)
            .Include(match => match.Stadium)
            .ThenInclude(stadium => stadium.StadiumLocation)
            .Include( m => m.AwayTeam)
            .Include(m => m.HomeTeam)
            .Where(m => m.MatchResult != null &&
                        (m.AwayTeamCode == teamAbbreviation || m.HomeTeamCode == teamAbbreviation))
            .ToListAsync()
            .ConfigureAwait(false);

        return results.Select(m => new MatchViewModel(m, m.MatchResult!)).ToList();
    }

    public async Task<List<MatchViewModel>> GetScheduleForThisTeam(string teamAbbreviation)
    {
        var schedule = await db.Matches.Include(m => m.MatchResult)
            .Include(match => match.Stadium)
            .ThenInclude(stadium => stadium.StadiumLocation)
            .Include(m => m.AwayTeam)
            .Include(m => m.HomeTeam)
            .Where(m => m.MatchResult == null &&
                        (m.AwayTeamCode == teamAbbreviation || m.HomeTeamCode == teamAbbreviation))
            .ToListAsync()
            .ConfigureAwait(false);

        return schedule.Select(m => new MatchViewModel(m)).ToList();
    }

    public async Task<List<PlayerInTeam>> GetPlayersFromTeamAsync(string teamAbbreviation)
    {
        return await db.Players.Where(p => p.TeamAbbreviation == teamAbbreviation).ToListAsync();
    }
}