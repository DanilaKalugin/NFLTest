using System.Text.Json.Serialization;

namespace Entities.Tables
{
    public class Stadium
    {
        public byte StadiumId { get; set; }
        public string StadiumTitle { get; set; }
        public City StadiumLocation { get; set; }
        [JsonIgnore]
        public short StadiumLocationId { get; set; }
        [JsonIgnore]
        public virtual List<Team> Teams { get; set; } = new();
        [JsonIgnore]
        public virtual List<Match> MatchesPlayedInThisStadium { get; set; } = new();
    }
}
