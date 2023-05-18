using Entities.Tables;
using Entities.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Coursework.DAL
{
    public class ConferencesDAO
    {
        private readonly CourseworkApplicationContext db;

        public ConferencesDAO(CourseworkApplicationContext courseworkApplicationContext) => db = courseworkApplicationContext;

        public async Task<Conference?> GetConferenceById(byte conferenceId) => await db.Conferences!.FindAsync(conferenceId);

        public async Task<List<TeamStandingsViewModel>> GetConferenceStandingsAsync(byte conferenceId)
        {
            var teams = await db.Teams!
                .Include(t => t.Colors)
                .ToListAsync();

            var standings = await db.TeamStandings.ToListAsync();

            return teams.Join(standings,
                    team => team.TeamAbbreviation,
                    teamRecord => teamRecord.TeamAbbreviation,
                    (team, teamStandings) => new TeamStandingsViewModel(team, teamStandings))
                .Where(t => t.TeamConference == conferenceId)
                .ToList();
        }
    }
}
