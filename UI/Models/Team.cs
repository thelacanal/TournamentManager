public class Team
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Game { get; set; } // To specify the game (e.g., Valorant, CS:GO, etc.)
    public string? Owner { get; set; } // The captain's name or ID
    // Add more properties as needed, e.g., team members, logo, description, etc.
    public string? Description { get; set; }
    // public Image LogoUrl { get; set; }

}