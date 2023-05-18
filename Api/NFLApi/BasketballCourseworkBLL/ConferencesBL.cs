using Coursework.DAL;
using Entities.Tables;
using Entities.ViewModels;

namespace Coursework.BLL;

public class ConferencesBL
{
    private readonly ConferencesDAO _conferencesDao;

    public ConferencesBL(ConferencesDAO conferencesDao)
    {
        _conferencesDao = conferencesDao;
    }
    
    public async Task<Conference?> GetConferenceByIdAsync(byte conferenceId) =>
        await _conferencesDao.GetConferenceById(conferenceId)
            .ConfigureAwait(false);

    public async Task<List<TeamStandingsViewModel>> GetConferenceStandingsAsync(byte conferenceId)
    {
        var standings = await _conferencesDao.GetConferenceStandingsAsync(conferenceId)
            .ConfigureAwait(false);
            
        return standings.OrderByDescending(t => t.TeamWins)
            .ThenBy(t => t.TeamRank)
            .ToList();
    }
}