using Entities.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NCAA.BLL;

namespace NFLApi.Controllers
{
    [Route("divisions")]
    [ApiController]
    public class DivisionsController : ControllerBase
    {
        private readonly TeamsBL _teamsBl = new();

        private readonly ILogger<DivisionsController> _logger;

        public DivisionsController(ILogger<DivisionsController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{conferenceNumber}")]
        [HttpOptions]
        public async Task<IEnumerable<Division>> Get(byte conferenceNumber)
        {
            var res = await _teamsBl.GetDivisionsFromConference(conferenceNumber)
                .ConfigureAwait(false);
            return res;
        }
    }
}
