using Coursework.BLL;
using Entities.Tables;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseworkApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/states")]
    public class StatesController : ControllerBase
    {
        private readonly StatesBL _statesBl;

        private readonly ILogger<StatesController> _logger;

        public StatesController(ILogger<StatesController> logger, StatesBL statesBl)
        {
            _logger = logger;
            _statesBl = statesBl;
        }
        
        [HttpGet, Route("", Name="4")]
        public async Task<IEnumerable<State>> GetStatesAsync()
        {
            var res = await _statesBl.GetStatesAsync()
                .ConfigureAwait(false);
            return res;
        }

        [HttpGet, Route("{stateCode}", Name = "5")]
        public async Task<ActionResult<State?>> GetStateByIdAsync(string stateCode)
        {
            var stateData = await _statesBl.GetStateByStateCodeAsync(stateCode)
                .ConfigureAwait(false);
            return stateData is null ? NotFound() : stateData;
        }
    }
}
