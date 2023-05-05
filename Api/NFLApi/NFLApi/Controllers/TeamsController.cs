using Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using NCAA.BLL;

namespace NFLApi.Controllers;

[ApiController]
[Route("teams")]
public class TeamsController : ControllerBase
{
    private readonly TeamsBL _teamsBl;

    private readonly ILogger<TeamsController> _logger;

    public TeamsController(ILogger<TeamsController> logger, TeamsBL teamsBl)
    {
        _logger = logger;
        _teamsBl = teamsBl;
    }

    [HttpGet, Route("conference/{division}", Name="6")]
    public async Task<IEnumerable<ShortTeamInfoViewModel>> GetTeamsFromDivision(byte division)
    {
        var res = await _teamsBl.GetTeamsFromConferenceAsync(division)
            .ConfigureAwait(false);
        return res;
    }
    
    [HttpGet("{team}", Name="7")]
    public async Task<FullTeamInfoViewModel?> GetTeamInfo(string team)
    {
        var res = await _teamsBl.GetTeam(team)
            .ConfigureAwait(false);
        return res;
    }

    [HttpGet("state/{stateCode}", Name="8")]
    public async Task<IEnumerable<ShortTeamInfoViewModel>> GetTeamsFromStateAsync(string stateCode)
    {
        return await _teamsBl.GetTeamsFromStateAsync(stateCode)
            .ConfigureAwait(false);
    }
}