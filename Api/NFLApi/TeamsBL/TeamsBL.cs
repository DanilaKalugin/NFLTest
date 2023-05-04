using Entities.Tables;
using NFL.DAO;

namespace NCAA.BLL
{
    public class TeamsBL
    {
        private readonly NFLDAO _nflDao = new();

        public async Task<List<Team>> GetTeamsFromConferenceAsync(byte division)
        {
            var teams = await _nflDao.GetTeamsFromConferenceAsync(division)
                .ConfigureAwait(false);
            return teams.OrderBy(t => t.TeamRank).ToList();
        }

        public async Task<List<Team>> GetTeam(string team) =>
            await _nflDao.GetTeam(team)
                .ConfigureAwait(false);

        public async Task<List<NationalDivision>> GetConferencesAsync()
        {
            return await _nflDao.GetAllConferences()
                .ConfigureAwait(false);
        }

        public async Task<List<State>> GetStatesAsync() =>
            await _nflDao.GetStatesAsync()
                .ConfigureAwait(false);

        public async Task<Conference?> GetConferenceByIdAsync(byte conferenceId) =>
            await _nflDao.GetConferenceById(conferenceId)
                .ConfigureAwait(false);

        public async Task<State?> GetStateByStateCodeAsync(string stateCode) =>
            await _nflDao.GetStateById(stateCode)
                .ConfigureAwait(false);

        public async Task<List<Team>> GetTeamsFromStateAsync(string stateCode) =>
            await _nflDao.GetTeamsFromState(stateCode);
    }
}