using Entities.Tables;
using Microsoft.AspNetCore.Mvc;
using NCAA.BLL;

namespace NFLApi.Controllers
{
    [Route("divisions")]
    [ApiController]
    public class DivisionsController : ControllerBase
    {
        private readonly DivisionsBL _divisionsBl;
        private readonly ILogger<DivisionsController> _logger;

        public DivisionsController(ILogger<DivisionsController> logger, DivisionsBL divisionsBl)
        {
            _logger = logger;
            _divisionsBl = divisionsBl;
        }

        [HttpGet, Route("", Name="3")]
        public async Task<IEnumerable<NationalDivision>> GetAllConferences() =>
            await _divisionsBl.GetConferencesAsync()
                .ConfigureAwait(false);
    }
}
