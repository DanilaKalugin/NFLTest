using Coursework.DAL;
using Entities.ViewModels;

namespace Coursework.BLL;

public class TeamsBL
{
    private readonly TeamsDAO _teamsDao;

    public TeamsBL(TeamsDAO teamsDao) => _teamsDao = teamsDao;

    public async Task<FullTeamInfoViewModel?> GetTeam(string team) =>
        await _teamsDao.GetTeam(team)
            .ConfigureAwait(false);

    public async Task<List<ShortTeamInfoViewModel>> GetTeamsFromStateAsync(string stateCode) =>
        await _teamsDao.GetTeamsFromState(stateCode)
            .ConfigureAwait(false);

    public async Task<List<ShortTeamInfoViewModel>> GetTeamsFromConferenceAsync(byte division) =>
        await _teamsDao.GetTeamsFromConferenceAsync(division)
            .ConfigureAwait(false);

    public async Task<List<ShortTeamInfoViewModel>> GetAllTeams()
    {
        var teams = await _teamsDao.GetAllTeams()
            .ConfigureAwait(false);

        return teams.OrderBy(t => t.TeamRegion).ToList();
    }

    public async Task<List<MatchViewModel>> GetMatchesForThisTeamAsync(string team) => 
        await _teamsDao.GetResultsOfMatchesForThisTeam(team)
            .ConfigureAwait(false);

    public async Task<List<MatchViewModel>> GetScheduleForThisTeamAsync(string team) => 
        await _teamsDao.GetScheduleForThisTeam(team)
            .ConfigureAwait(false);

    public async Task<List<DepthChartItemViewModel>> GetDepthChartForTeam(string teamAbbreviation)
    {
        var players = await _teamsDao.GetPlayersFromTeamAsync(teamAbbreviation).ConfigureAwait(false);

        return players.GroupBy(p => new { p.PlayerRole, p.PlayerPosition }).Select(g =>
            new DepthChartItemViewModel(g.Key.PlayerRole, g.Key.PlayerPosition, g.ToList())).ToList();
    }
}