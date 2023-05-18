using Entities.Tables;

namespace Entities.AbstractClasses
{
    public abstract class MatchBaseClass
    {
        public int MatchId { get; set; }
        public Team HomeTeam { get; set; }
        public string HomeTeamCode { get; set; }
        public Team AwayTeam { get; set; }
        public string AwayTeamCode { get; set; }
        public DateTime MatchDate { get; set; }
        public Stadium Stadium { get; set; }
        public short StadiumId { get; set; }
    }
}
