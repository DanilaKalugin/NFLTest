namespace Entities.Tables;

public class User
{
    public int UserId { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string? FavoriteTeamAbbreviation { get;set; }
    public Team FavoriteTeam { get; set; }
    public virtual List<MatchTicket> Bookings { get; set; }
}