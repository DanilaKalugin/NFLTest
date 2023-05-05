using Entities.Tables;
using Entities.ViewModels;
using NFL.DAO;

namespace NCAA.BLL;

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


    public async Task<List<TeamStandingsViewModel>> GetConferenceStandingsAsync(byte conferenceId) =>
        await _conferencesDao.GetConferenceStandingsAsync(conferenceId)
            .ConfigureAwait(false);
}