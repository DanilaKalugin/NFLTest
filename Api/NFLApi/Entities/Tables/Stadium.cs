using System.Text.Json.Serialization;

namespace Entities.Tables
{
    public class Stadium
    {
        public short StadiumId { get; set; }
        public string StadiumTitle { get; set; }
        public City StadiumLocation { get; set; }
        [JsonIgnore] public short StadiumLocationId { get; set; }
        public int StadiumCapacity { get; set; }
        public short StadiumOpeningYear { get; set; }
        [JsonIgnore] public virtual List<Team> Teams { get; set; } = new();
        [JsonIgnore] public virtual List<Match> MatchesPlayedInThisStadium { get; set; } = new();

        public int StadiumClass =>
            StadiumCapacity switch
            {
                <= 1000 => 1,
                <= 5000 => 2,
                <= 10000 => 3,
                _ => 4
            };

        public short StadiumBookingSectorWidth =>
            StadiumClass switch
            {
                1 => 5,
                2 => 10,
                3 => 12,
                _ => 15
            };

        public byte StadiumBookingSectorHeight =>
            StadiumClass switch
            {
                1 => 5,
                2 => 7,
                3 => 10,
                _ => 12
            };
    }
}
