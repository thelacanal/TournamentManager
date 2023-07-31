public class Tournament
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime Date { get; set; }
    public double PricePool { get; set; }
    public double Fee { get; set; }
    public int Slots { get; set; }
    public List<Team> Teams { get; set; }
    // public Format Format { get; set; }
    // Add more properties as needed
}