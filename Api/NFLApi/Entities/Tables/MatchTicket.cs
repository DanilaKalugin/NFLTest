using System.Text.Json.Serialization;

namespace Entities.Tables;

public class MatchTicket
{
    [JsonIgnore]
    public int TicketId { get; set; }
    [JsonIgnore]
    public Match Match { get; set; }
    [JsonIgnore]
    public int MatchId { get; set; }
    [JsonIgnore]
    public User User { get; set; }
    [JsonIgnore]
    public int UserId { get; set; }
    public byte Row { get; set; }
    public byte Seat { get; set; }
}