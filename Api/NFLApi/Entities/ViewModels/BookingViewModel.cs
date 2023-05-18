using Entities.Tables;

namespace Entities.ViewModels;

public class BookingViewModel
{
    public int MatchId { get; set; }
    public string AwayTeam { get; set; }
    public string HomeTeam { get; set; }
    public StadiumViewModel Stadium { get; set; }
    public List<MatchTicket> SoldTickets { get; set; }

    public BookingViewModel(Match match, Stadium stadium, List<MatchTicket> soldTickets)
    {
        MatchId = match.MatchId;
        AwayTeam = match.AwayTeam.TeamRegion;
        HomeTeam = match.HomeTeam.TeamRegion;
        Stadium = new StadiumViewModel(stadium);
        SoldTickets = soldTickets;
    }
}