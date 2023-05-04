using Entities.Tables;
using Microsoft.AspNetCore.Mvc;
using NCAA.BLL;

namespace NFLApi.Controllers
{
    [Route("conferences")]
    [ApiController]
    public class ConferencesController : ControllerBase
    {
        private readonly TeamsBL _teamsBl = new();

        private readonly ILogger<ConferencesController> _logger;

        public ConferencesController(ILogger<ConferencesController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{conferenceId}")]
        [HttpOptions]
        public async Task<Conference?> GetConferenceById(byte conferenceId)
        {
            return await _teamsBl.GetConferenceByIdAsync(conferenceId)
                .ConfigureAwait(false);
        }
    }
}
