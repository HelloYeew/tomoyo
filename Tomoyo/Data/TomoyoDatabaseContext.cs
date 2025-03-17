using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tomoyo.Core.Models;
using Tomoyo.Core.Utilities.Data;

namespace Tomoyo.Data;

public class TomoyoDatabaseContext(DbContextOptions<TomoyoDatabaseContext> options)
    : IdentityDbContext<TomoyoUser>(options)
{
    public DbSet<Profile> Profiles { get; set; }
    
    public DbSet<Photo> Pictures { get; set; }
    
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

        builder.Entity<TomoyoUser>()
            .HasMany(p => p.UploadPhotos)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UploadUserId);

        #endregion

        #region User Limitation

        builder.Entity<TomoyoUser>()
            .Property(x => x.UserName)
            .HasMaxLength(30);

        #endregion

        #region DateTime auto update

        builder.Entity<Photo>()
            .Property(x => x.CreatedAt)
            .HasDefaultValueSql("GETDATE()");
        
        builder.Entity<Photo>()
            .Property(x => x.UpdatedAt)
            .HasDefaultValueSql("GETDATE()");
        
        // TODO: Update UpdatedAt when the entity is updated

        #endregion
    }
}