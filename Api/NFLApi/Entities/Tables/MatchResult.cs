﻿namespace Entities.Tables;

public class MatchResult
{
    public Match Match { get; set; }
    public int MatchId { get; set; }
    public short AwayTeamScore { get; set; }
    public short HomeTeamScore { get; set; }
    public Team MatchWinner { get; set; }
    public string MatchWinnerId { get; set; }
    public Team MatchLoser { get; set; }
    public string MatchLoserId { get; set; }
    public byte OvertimesCount { get; set; }
}