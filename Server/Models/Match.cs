public class Match
{
    public int Id { get; set; }
    public int TournamentId { get; set; }
    public int Team1 { get; set; }
    public int Team2{ get; set; }
    public int Score1 { get; set; }
    public int Score2 { get; set; }
    
    public int Winner() => Score1 > Score2 ? Team1 : Team2;
}