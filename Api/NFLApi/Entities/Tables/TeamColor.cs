using System.Text.Json.Serialization;

namespace Entities.Tables;

public class TeamColor
{
    [JsonIgnore]
    public Team Team { get; set; }
    public string TeamAbbreviation { get; set; }
    
    public byte ColorNumber { get; set; }
    public string Color { get; set; }
}