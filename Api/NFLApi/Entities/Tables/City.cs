using System.Text.Json.Serialization;

namespace Entities.Tables
{
    public class City
    {
        public short CityCode { get; set; }
        public string CityTitle { get; set; }
        public string CityStateId { get; set; }
        [JsonIgnore]
        public State CityState { get; set; }
        [JsonIgnore] 
        public virtual List<Stadium> Stadiums { get; set; } = new();

        public string CityLocation => $"{CityTitle}, {CityStateId}";
    }
}
