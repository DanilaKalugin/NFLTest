using Entities.Tables;
using Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using NCAA.BLL;

namespace NFLApi.Controllers
{
    [Route("conferences")]
    [ApiController]
    public class ConferencesController : ControllerBase
    {
        private readonly ConferencesBL _conferencesBl;
        private readonly ILogger<ConferencesController> _logger;

        public ConferencesController(ILogger<ConferencesController> logger, ConferencesBL conferencesBl)
        {
            _logger = logger;
            _conferencesBl = conferencesBl;
        }

        [HttpGet, Route("{conferenceId}", Name = "2")]
        [HttpOptions]
        public async Task<Conference?> GetConferenceById(byte conferenceId) =>
            await _conferencesBl.GetConferenceByIdAsync(conferenceId)
                .ConfigureAwait(false);

        [HttpGet,Route("standings/{conferenceId}", Name = "1")]
        public async Task<List<TeamStandingsViewModel>> GetConferenceStandings(byte conferenceId) =>
            await _conferencesBl.GetConferenceStandingsAsync(conferenceId)
                .ConfigureAwait(false);
    }
}
