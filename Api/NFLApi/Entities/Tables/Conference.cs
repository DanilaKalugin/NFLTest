using System.Text.Json.Serialization;

namespace Entities.Tables;

public class Conference
{
    public byte ConferenceId { get; set; }
    public string ConferenceName { get; set; }
    public string ConferenceColor { get; set; }
    [JsonIgnore]
    public byte? ConferenceLevel { get; set; }
    [JsonIgnore]
    public NationalDivision Division { get; set; }
    [JsonIgnore]
    public virtual List<Team> Teams { get; set; } = new();
}