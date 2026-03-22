using Microsoft.EntityFrameworkCore;
using AIReelBooster.API.Models.Domain;

namespace AIReelBooster.API.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<UserPlan>       UserPlans       => Set<UserPlan>();
    public DbSet<InstagramToken> InstagramTokens => Set<InstagramToken>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserPlan>().HasKey(u => u.UserId);
        modelBuilder.Entity<InstagramToken>().HasKey(t => t.UserId);
    }
}
