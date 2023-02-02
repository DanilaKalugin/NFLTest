using Entities.Tables;
using NFL.DAO;

namespace NCAA.BLL
{
    public class TeamsBL
    {
        private readonly NFLDAO _nflDao = new();

        public async Task<List<Team>> GetTeamsFromDivisionAsync(byte division)
        {
            var teams = await _nflDao.GetTeamsFromDivisionAsync(division)
                .ConfigureAwait(false);
            return teams.OrderBy(t => t.TeamRank).ToList();
        }

        public async Task<List<Team>> GetTeam(string team) =>
            await _nflDao.GetTeam(team)
                .ConfigureAwait(false);

        public async Task<List<Conference>> GetConferencesAsync() =>
            await _nflDao.GetAllConferences()
                .ConfigureAwait(false);

        public async Task<List<Division>> GetDivisionsFromConference(byte conferenceNumber) =>
            await _nflDao.GetDivisionsFromConference(conferenceNumber)
                .ConfigureAwait(false);
    }
}