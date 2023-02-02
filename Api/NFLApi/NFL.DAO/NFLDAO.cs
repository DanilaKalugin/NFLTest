using Entities.Tables;
using Microsoft.EntityFrameworkCore;

namespace NFL.DAO;

public class NFLDAO
{
    public async Task<List<Team>> GetTeamsFromDivisionAsync(byte division)
    {
        await using var db = new NFLApplicationContext();
        return await db.Teams.Where(t => t.DivisionID == division)
            .Include(t => t.Colors)
            .ToListAsync();
    }
    
    public async Task<List<Team>> GetTeam(string teamAbbreviation)
    {
        await using var db = new NFLApplicationContext();
        return await db.Teams.Where(t => t.TeamAbbreviation == teamAbbreviation)
            .Include(t => t.Division)
            .Include(t => t.Stadium)
            .ThenInclude(s => s.StadiumLocation)
            .Include(t => t.Colors.Where(tc => tc.TeamAbbreviation == teamAbbreviation))
            .ToListAsync();
    }

    public async Task<List<Conference>> GetAllConferences()
    {
        await using var db = new NFLApplicationContext();
        return await db.Conferences.Include(c => c.Divisions)
            .ToListAsync()
            .ConfigureAwait(false);
    }

    public async Task<List<Division>> GetDivisionsFromConference(byte conferenceNumber)
    {
        await using var db = new NFLApplicationContext();
        return await db.Divisions
            .Where(d => d.ConferenceId == conferenceNumber)
            .ToListAsync()
            .ConfigureAwait(false);
    }
}