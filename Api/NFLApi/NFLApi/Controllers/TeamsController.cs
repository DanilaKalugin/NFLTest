using System.Runtime.CompilerServices;
using Entities.Tables;
using Microsoft.AspNetCore.Mvc;
using NCAA.BLL;

namespace NFLApi.Controllers;

[ApiController]
[Route("teams")]
public class TeamsController : ControllerBase
{
    private readonly TeamsBL _teamsBl = new();

    private readonly ILogger<TeamsController> _logger;

    public TeamsController(ILogger<TeamsController> logger)
    {
        _logger = logger;
    }

    [HttpGet("conference/{division}")]
    [HttpOptions]
    public async Task<IEnumerable<Team>> GetTeamsFromDivision(byte division)
    {
        var res = await _teamsBl.GetTeamsFromConferenceAsync(division)
            .ConfigureAwait(false);
        return res;
    }
    
    [HttpGet("team/{team}")]
    [HttpOptions]
    public async Task<IEnumerable<Team>> GetTeamInfo(string team)
    {
        var res = await _teamsBl.GetTeam(team)
            .ConfigureAwait(false);
        return res;
    }

    [HttpGet("state/{stateCode}")]
    public async Task<IEnumerable<Team>> GetTeamsFromStateAsync(string stateCode)
    {
        return await _teamsBl.GetTeamsFromStateAsync(stateCode)
            .ConfigureAwait(false);
    }
}