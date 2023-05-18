using Entities.AbstractClasses;

namespace Entities.Tables;

public class Match: MatchBaseClass
{
    public MatchResult? MatchResult { get; set; }
    public bool IsPlayed { get;set; }
    public virtual List<MatchTicket> MatchTickets { get; set; } = new();
}