using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tomoyo.Utilities.Data;

namespace Tomoyo.Data;

public class TomoyoDatabaseContext(DbContextOptions<TomoyoDatabaseContext> options)
    : IdentityDbContext<TomoyoUser>(options)
{
    public DbSet<BaseProfile> BaseProfiles { get; set; }
    public DbSet<CosplayerProfile> CosplayerProfiles { get; set; }
    public DbSet<PhotographerProfile> PhotographerProfiles { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        #region Seed data
        
        foreach (var role in TomoyoStarterData.Roles)
        {
            builder.Entity<TomoyoRole>().HasData(role);
        }
        
        #endregion

        #region Foreign key relation

        builder.Entity<TomoyoUser>()
            .HasOne(p => p.BaseProfile)
            .WithOne(p => p.User)
            .HasForeignKey<BaseProfile>(p => p.UserId)
            .IsRequired();

        builder.Entity<TomoyoUser>()
            .HasOne(p => p.CosplayerProfile)
            .WithOne(p => p.User)
            .HasForeignKey<CosplayerProfile>(p => p.UserId)
            .IsRequired(false);
        
        builder.Entity<TomoyoUser>()
            .HasOne(p => p.PhotographerProfile)
            .WithOne(p => p.User)
            .HasForeignKey<PhotographerProfile>(p => p.UserId)
            .IsRequired(false);

        #endregion
        
    }
}