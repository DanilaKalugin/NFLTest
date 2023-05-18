using Coursework.BLL;
using Microsoft.AspNetCore.Mvc;

namespace CourseworkApi.Controllers;

[Route("api/matches")]
[ApiController]
public class MatchMessageController: ControllerBase
{
    public IConfiguration _configuration { get; set; }
    private MatchesBL _matchesBL { get; }

    public MatchMessageController(MatchesBL matchesBl, IConfiguration configuration)
    {
        _matchesBL = matchesBl;
        _configuration = configuration;
    }
    

    [HttpGet("message/{team}", Name = "14")]
    [ProducesResponseType(typeof((bool, string)), 200)]
    [ProducesResponseType(typeof(UnauthorizedResult), 401)]
    public async Task<IActionResult> GetMessageAboutTeamLastMatch(string team)
    {
        var message = await _matchesBL.GetMessageAboutLastTeamMatch(team);
        return Ok(new { matchesPlayed = message is not null, message });
    }
}