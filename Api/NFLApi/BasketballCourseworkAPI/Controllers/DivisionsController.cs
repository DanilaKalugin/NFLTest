using Coursework.BLL;
using Entities.Tables;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CourseworkApi.Controllers
{
    [Route("api/divisions")]
    [ApiController]
    [Authorize]
    [EnableCors("MyPolicy")]
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
        [ProducesResponseType(typeof(List<NationalDivision>), 200)]
        [ProducesResponseType(typeof(UnauthorizedResult), 401)]
        public async Task<IEnumerable<NationalDivision>> GetAllConferences() =>
            await _divisionsBl.GetConferencesAsync()
                .ConfigureAwait(false);
    }
}
