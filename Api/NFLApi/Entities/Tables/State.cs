using System.Text.Json.Serialization;

namespace Entities.Tables;

public class State
{
    public string StateCode { get; set; }
    public string StateTitle { get; set; }
    [JsonIgnore]
    public virtual List<City> Cities { get; set; } = new();
}