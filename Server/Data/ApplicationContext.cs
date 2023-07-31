using Microsoft.EntityFrameworkCore;

public class ApplicationContext : DbContext
{


    #nullable disable
    public DbSet<Tournament> Tournaments { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Match> Matches { get; set; }
    #nullable restore
    // Add more DbSet properties for other models as needed

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure relationships, constraints, etc. between models
        // Add any additional configurations needed
        modelBuilder.Entity<Tournament>()
            .HasMany(t => t.Teams);
            // .WithMany(t => t.Tournaments);
        

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    optionsBuilder.UseSqlite("data source=TournamentsDB.sqlite");
    }
    
}
