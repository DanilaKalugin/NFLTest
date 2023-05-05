using System.Text.Json.Serialization;

namespace Entities.Tables
{
    public class Team
    {
        public string TeamAbbreviation { get; set; }
        public string TeamRegion { get; set; }
        public string TeamName { get; set; }
        public Stadium Stadium { get; set; }
        public byte StadiumId { get; set; }
        public byte ConferenceId { get; set; }
        public Conference Conference { get; set; }
        public string Coach { get; set; }
        public short? TeamRank { get; set; }

        public virtual List<TeamColor> Colors { get; set; } = new();
        public virtual List<Match> AwayMatches { get; set; } = new();
        public virtual List<Match> HomeMatches { get; set; } = new();
        public virtual List<MatchResult> MatchWinners { get; set; } = new();
        public virtual List<MatchResult> MatchLosers { get; set; } = new();
        public virtual List<SocialNetworkAccount> SocialNetworkAccounts { get; set; } = new();
    }
}