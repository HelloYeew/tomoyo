using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Tomoyo.Core.Models;
using Tomoyo.Core.Utilities.Data;

namespace Tomoyo.Data;

public class TomoyoDatabaseContext(DbContextOptions<TomoyoDatabaseContext> options)
    : IdentityDbContext<TomoyoUser>(options)
{
    public DbSet<Profile> Profiles { get; set; }
    
    public DbSet<Photo> Photos { get; set; }
    
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
            .WithOne(p => p.UploadUser)
            .HasForeignKey(p => p.UploadUserId);

        #endregion

        #region User Limitation

        builder.Entity<TomoyoUser>()
            .Property(x => x.UserName)
            .HasMaxLength(30);

        #endregion
    }

    public override int SaveChanges()
    {
        foreach (EntityEntry entry in ChangeTracker.Entries())
        {
            if (entry.Entity is Photo photo)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        photo.CreatedAt = DateTime.Now;
                        photo.UpdatedAt = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        photo.UpdatedAt = DateTime.Now;
                        break;
                }
            }
        }
        
        return base.SaveChanges();
    }
}