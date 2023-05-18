using Coursework.DAL;
using Entities.DTOs;
using Entities.ViewModels;

namespace Coursework.BLL;

public class TicketsBL
{
    private readonly StadiumsDAO _stadiumsDao;
    private readonly MatchesDAO _matchesDao;

    public TicketsBL(StadiumsDAO stadiumsDao, MatchesDAO matchesDao)
    {
        _stadiumsDao = stadiumsDao;
        _matchesDao = matchesDao;
    }

    public async Task<BookingViewModel> GetReservedSeatsForThisMatch(int matchId)
    {
        var match = await _matchesDao.GetMatchById(matchId);
        
        var stadium = await _stadiumsDao.GetStadiumById(match!.StadiumId);

        var tickets = await _matchesDao.GetSoldTicketsForThisMatch(match.MatchId);

        return new BookingViewModel(match, stadium, tickets);
    }

    public async Task BookTicket(MatchTicketDto ticket)
    {
        await _matchesDao.BookTicket(ticket);
    }
}