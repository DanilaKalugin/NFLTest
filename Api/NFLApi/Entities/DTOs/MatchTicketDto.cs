namespace Entities.DTOs;

public class MatchTicketDto
{
    public int MatchId { get; set; }
    public int UserId { get; set; }
    public byte Row { get; set; }
    public byte Seat { get; set; }
}