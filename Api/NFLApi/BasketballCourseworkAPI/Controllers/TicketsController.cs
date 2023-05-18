using Coursework.BLL;
using Entities.DTOs;
using Entities.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseworkApi.Controllers
{
    [Route("api/tickets")]
    [Authorize]
    [ApiController]

    public class TicketsController : ControllerBase
    {
        private TicketsBL _ticketsBl { get; }

        public TicketsController(TicketsBL ticketsBl)
        {
            _ticketsBl = ticketsBl;
        }
        
        [HttpGet("{matchId}", Name = "15")]
        [ProducesResponseType(typeof(BookingViewModel), 200)]
        [ProducesResponseType(typeof(UnauthorizedResult), 401)]
        public async Task<BookingViewModel> GetAvailableTicketsForMatch(int matchId)
        {
            var bookingInfo = await _ticketsBl.GetReservedSeatsForThisMatch(matchId);

            return bookingInfo;
        }

        [HttpPost("{matchId}/bookTicket", Name = "16")]
        [ProducesResponseType(typeof(CreatedResult), 201)]
        [ProducesResponseType(typeof(UnauthorizedResult), 401)]
        public async Task<IActionResult> CreateNewBook([FromBody] MatchTicketDto matchTicketDto)
        {
            await _ticketsBl.BookTicket(matchTicketDto);
            return Created("~/api/register", new { id = matchTicketDto.MatchId });
        }
    }
}
