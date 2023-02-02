using Entities.Tables;
using Microsoft.AspNetCore.Http;
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

        [HttpGet]
        [HttpOptions]
        public async Task<IEnumerable<Conference>> Get()
        {
            var res = await _teamsBl.GetConferencesAsync()
                .ConfigureAwait(false);
            return res;
        }
    }
}
