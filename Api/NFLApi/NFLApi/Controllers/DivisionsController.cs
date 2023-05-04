using Entities.Tables;
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

        
        [HttpGet]
        public async Task<IEnumerable<NationalDivision>> GetAllConferences()
        {
            var res = await _teamsBl.GetConferencesAsync()
                .ConfigureAwait(false);
            return res;
        }
    }
}
