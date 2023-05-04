using Entities.Tables;
using Microsoft.AspNetCore.Mvc;
using NCAA.BLL;

namespace NFLApi.Controllers
{
    [ApiController]
    [Route("states")]
    public class StatesController : ControllerBase
    {
        private readonly TeamsBL _teamsBl = new();

        private readonly ILogger<StatesController> _logger;

        public StatesController(ILogger<StatesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<State>> GetStatesAsync()
        {
            var res = await _teamsBl.GetStatesAsync()
                .ConfigureAwait(false);
            return res;
        }

        [HttpGet("{stateCode}")]
        public async Task<State?> GetStateByIdAsync(string stateCode) => 
            await _teamsBl.GetStateByStateCodeAsync(stateCode)
                .ConfigureAwait(false);
    }
}
