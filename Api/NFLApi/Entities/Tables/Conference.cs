using System.Text.Json.Serialization;

namespace Entities.Tables;

public class Conference
{
    public byte ConferenceId { get; set; }
    public string ConferenceName { get; set; }
    public string ConferenceColor { get; set; }
    public virtual List<Division> Divisions { get; set; } = new();
}