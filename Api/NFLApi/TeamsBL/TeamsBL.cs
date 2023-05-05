using Entities.ViewModels;
using NFL.DAO;

namespace NCAA.BLL;

public class TeamsBL
{

    private readonly TeamsDAO _teamsDao;

    public TeamsBL(TeamsDAO teamsDao)
    {
        _teamsDao = teamsDao;
    }

    public async Task<FullTeamInfoViewModel?> GetTeam(string team) =>
        await _teamsDao.GetTeam(team)
            .ConfigureAwait(false);

    public async Task<List<ShortTeamInfoViewModel>> GetTeamsFromStateAsync(string stateCode) =>
        await _teamsDao.GetTeamsFromState(stateCode)
            .ConfigureAwait(false);

    public async Task<List<ShortTeamInfoViewModel>> GetTeamsFromConferenceAsync(byte division) =>
        await _teamsDao.GetTeamsFromConferenceAsync(division)
            .ConfigureAwait(false);
}