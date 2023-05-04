using Entities.Tables;
using Microsoft.EntityFrameworkCore;

namespace NFL.DAO;

public class NFLDAO
{
    public async Task<List<Team>> GetTeamsFromConferenceAsync(byte division)
    {
        await using var db = new NFLApplicationContext();
        return await db.Teams!.Where(t => t.ConferenceId == division)
            .Include(t => t.Colors)
            .ToListAsync();
    }

    public async Task<List<Team>> GetTeam(string teamAbbreviation)
    {
        await using var db = new NFLApplicationContext();
        return await db.Teams!.Where(t => t.TeamAbbreviation == teamAbbreviation)
            .Include(t => t.Conference)
            .Include(t => t.Stadium)
            .ThenInclude(s => s.StadiumLocation)
            .Include(t => t.Colors.Where(tc => tc.TeamAbbreviation == teamAbbreviation))
            .ToListAsync();
    }

    public async Task<List<NationalDivision>> GetAllConferences()
    {
        await using var db = new NFLApplicationContext();
        return await db.Divisions1
            .Include(d => d.Conferences)
            .ToListAsync()
            .ConfigureAwait(false);
    }

    public async Task<List<State>> GetStatesAsync()
    {
        await using var db = new NFLApplicationContext();
        return await db.States!
            .ToListAsync()
            .ConfigureAwait(false);
    }

    public async Task<Conference?> GetConferenceById(byte conferenceId)
    {
        await using var db = new NFLApplicationContext();
        return await db.Conferences!.FindAsync(conferenceId);
    }

    public async Task<State?> GetStateById(string stateCode)
    {
        await using var db = new NFLApplicationContext();
        return await db.States!
            .FindAsync(stateCode)
            .ConfigureAwait(false);
    }

    public async Task<List<Team>> GetTeamsFromState(string stateCode)
    {
        await using var db = new NFLApplicationContext();
        return await db.Teams!.Include(t => t.Stadium)
            .ThenInclude(s => s.StadiumLocation)
            .Include(t => t.Colors)
            .Where(t => t.Stadium.StadiumLocation.CityStateId == stateCode)
            .ToListAsync()
            .ConfigureAwait(false);
    }
}