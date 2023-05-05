using Entities.Tables;
using Entities.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace NFL.DAO
{
    public class ConferencesDAO
    {
        public async Task<Conference?> GetConferenceById(byte conferenceId)
        {
            await using var db = new NFLApplicationContext();
            return await db.Conferences!.FindAsync(conferenceId);
        }

        public async Task<List<TeamStandingsViewModel>> GetConferenceStandingsAsync(byte conferenceId)
        {
            await using var db = new NFLApplicationContext();

            var teams = await db.Teams!
                .Include(t => t.Colors)
                .ToListAsync();

            var standings = await db.TeamStandings.ToListAsync();

            return teams.Join(standings,
                    team => team.TeamAbbreviation,
                    teamRecord => teamRecord.TeamAbbreviation,
                    (team, teamStandings) => new TeamStandingsViewModel(team, teamStandings))
                .Where(t => t.TeamConference == conferenceId)
                .OrderByDescending(t => t.TeamWins)
                .ThenBy(t => t.TeamRank)
                .ToList();
        }
    }
}
