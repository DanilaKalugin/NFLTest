using Coursework.BLL;
using Entities.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseworkApi.Controllers;

[ApiController]
[Route("api/teams")]
public class TeamsController : ControllerBase
{
    private readonly TeamsBL _teamsBl;

    private readonly ILogger<TeamsController> _logger;

    public TeamsController(ILogger<TeamsController> logger, TeamsBL teamsBl)
    {
        _logger = logger;
        _teamsBl = teamsBl;
    }
    
    [Authorize]
    [HttpGet, Route("conference/{division}", Name = "6")]
    [ProducesResponseType(typeof(IEnumerable<ShortTeamInfoViewModel>), 200)]
    [ProducesResponseType(401)]
    public async Task<IEnumerable<ShortTeamInfoViewModel>> GetTeamsFromDivision(byte division)
    {
        var res = await _teamsBl.GetTeamsFromConferenceAsync(division)
            .ConfigureAwait(false);
        return res;
    }

    [Authorize]
    [HttpGet("{team}", Name = "7")]
    [ProducesResponseType(typeof(IEnumerable<ShortTeamInfoViewModel>), 200)]
    [ProducesResponseType(typeof(NotFoundResult), 404)]
    [ProducesResponseType(typeof(UnauthorizedResult), 401)]
    public async Task<ActionResult<FullTeamInfoViewModel?>> GetTeamInfo(string team)
    {
        var res = await _teamsBl.GetTeam(team)
            .ConfigureAwait(false);
        return res is null ? NotFound() : res;
    }

    [Authorize]
    [HttpGet("state/{stateCode}", Name = "8")]
    [ProducesResponseType(typeof(IEnumerable<ShortTeamInfoViewModel>), 200)]
    [ProducesResponseType(typeof(UnauthorizedResult), 401)]
    public async Task<IEnumerable<ShortTeamInfoViewModel>> GetTeamsFromStateAsync(string stateCode)
    {
        return await _teamsBl.GetTeamsFromStateAsync(stateCode)
            .ConfigureAwait(false);
    }

    [HttpGet("", Name = "9")]
    [ProducesResponseType(typeof(IEnumerable<ShortTeamInfoViewModel>), 200)]
    public async Task<IEnumerable<ShortTeamInfoViewModel>> GetAllTeams()
    {
        return await _teamsBl.GetAllTeams()
            .ConfigureAwait(false);
    }

    [Authorize]
    [HttpGet("{team}/results", Name = "12")]
    [ProducesResponseType(typeof(IEnumerable<MatchViewModel>), 200)]
    [ProducesResponseType(typeof(UnauthorizedResult), 401)]
    public async Task<IEnumerable<MatchViewModel>> GetMatchesForThisTeam(string team)
    {
        return await _teamsBl.GetMatchesForThisTeamAsync(team)
            .ConfigureAwait(false);
    }

    [Authorize]
    [HttpGet("{team}/schedule", Name = "13")]
    [ProducesResponseType(typeof(IEnumerable<MatchViewModel>), 200)]
    public async Task<IEnumerable<MatchViewModel>> GetScheduleForThisTeam(string team)
    {
        return await _teamsBl.GetScheduleForThisTeamAsync(team)
            .ConfigureAwait(false);
    }

    [Authorize]
    [HttpGet("{team}/depth-chart", Name="17")]
    [ProducesResponseType(typeof(IEnumerable<DepthChartItemViewModel>), 200)]
    [ProducesResponseType(typeof(UnauthorizedResult), 401)]
    public async Task<IEnumerable<DepthChartItemViewModel>> GetDepthChartForTeam(string team)
    {
        return await _teamsBl.GetDepthChartForTeam(team)
            .ConfigureAwait(false);
    }
}