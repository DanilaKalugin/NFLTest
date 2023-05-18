using Entities.DTOs;
using Entities.Tables;
using Microsoft.EntityFrameworkCore;

namespace Coursework.DAL;

public class MatchesDAO
{
    private readonly CourseworkApplicationContext db;

    public MatchesDAO(CourseworkApplicationContext courseworkApplicationContext) => db = courseworkApplicationContext;

    public async Task<MatchResult?> GetLastMatchForThisTeamAsync(string team)
    {
        var IdForLastPlayedMatch =  await db.MatchIds
            .Where(m => m.TeamAbbreviation == team)
            .Select(m => m.MatchId).FirstAsync();

        if (IdForLastPlayedMatch == null) return null;

        return await db.MatchResults.Include(m => m.MatchWinner)
            .Include(m => m.MatchLoser)
            .FirstAsync(m => m.MatchId == IdForLastPlayedMatch);
    }

    public async Task<Match?> GetMatchById(int matchId)
    {
        return await db.Matches.Include(m => m.AwayTeam)
            .Include(m => m.HomeTeam)
            .FirstOrDefaultAsync(m => m.MatchId == matchId);
    }

    public async Task<List<MatchTicket>> GetSoldTicketsForThisMatch(int matchId)
    {
        return await db.Tickets
            .Where(m => m.MatchId == matchId)
            .ToListAsync();
    }

    public async Task BookTicket(MatchTicketDto ticket)
    {
        var newTicket = new MatchTicket
        {
            UserId = ticket.UserId,
            MatchId = ticket.MatchId,
            Row = ticket.Row,
            Seat = ticket.Seat
        };

        await db.Tickets.AddAsync(newTicket);
        await db.SaveChangesAsync();
    }
}