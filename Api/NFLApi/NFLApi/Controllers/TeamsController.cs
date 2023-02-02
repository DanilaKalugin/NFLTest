using Entities.Tables;
using Microsoft.AspNetCore.Mvc;
using NCAA.BLL;

namespace NFLApi.Controllers;

[ApiController]
[Route("Teams")]
public class TeamsController : ControllerBase
{
    private readonly TeamsBL _teamsBl = new();

    private readonly ILogger<TeamsController> _logger;

    public TeamsController(ILogger<TeamsController> logger)
    {
        _logger = logger;
    }

    [HttpGet("division/{division}")]
    [HttpOptions]
    public async Task<IEnumerable<Team>> Get(byte division)
    {
        var res = await _teamsBl.GetTeamsFromDivisionAsync(division)
            .ConfigureAwait(false);
        return res;
    }
    
    [HttpGet("team/{team}")]
    [HttpOptions]
    public async Task<IEnumerable<Team>> Get(string team)
    {
        var res = await _teamsBl.GetTeam(team)
            .ConfigureAwait(false);
        return res;
    }
}