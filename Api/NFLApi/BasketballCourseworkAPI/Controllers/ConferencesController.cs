using Coursework.BLL;
using Entities.Tables;
using Entities.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CourseworkApi.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/conferences")]
    [ApiController]
    [Authorize]
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
        [ProducesResponseType(typeof(Conference), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(UnauthorizedResult), 401)]
        public async Task<ActionResult<Conference?>> GetConferenceById(byte conferenceId)
        {
            var conferenceData = await _conferencesBl.GetConferenceByIdAsync(conferenceId)
                .ConfigureAwait(false);
            return conferenceData is null ? NotFound() : conferenceData;
        }

        [HttpGet, Route("{conferenceId}/standings", Name = "1")]
        [ProducesResponseType(typeof(List<TeamStandingsViewModel>), 200)]
        [ProducesResponseType(typeof(UnauthorizedResult), 401)]
        public async Task<List<TeamStandingsViewModel>> GetConferenceStandings(byte conferenceId) =>
            await _conferencesBl.GetConferenceStandingsAsync(conferenceId)
                .ConfigureAwait(false);
    }
}
