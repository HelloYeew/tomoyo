using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tomoyo.Core.Models;
using Tomoyo.Core.Utilities.Data;

namespace Tomoyo.Data;

public class TomoyoDatabaseContext(DbContextOptions<TomoyoDatabaseContext> options)
    : IdentityDbContext<TomoyoUser>(options)
{
    public DbSet<Profile> Profiles { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        #region Seed data
        
        foreach (var role in StarterData.Roles)
        {
            builder.Entity<TomoyoRole>().HasData(role);
        }
        
        #endregion

        #region Foreign key relation

        builder.Entity<TomoyoUser>()
            .HasOne(p => p.Profile)
            .WithOne(p => p.User)
            .HasForeignKey<Profile>(p => p.UserId)
            .IsRequired();

        #endregion

        #region User Limitation

        builder.Entity<TomoyoUser>()
            .Property(x => x.UserName)
            .HasMaxLength(30);

        #endregion
    }
}