using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tomoyo.Utilities.Data;

namespace Tomoyo.Data;

public class TomoyoDatabaseContext(DbContextOptions<TomoyoDatabaseContext> options)
    : IdentityDbContext<TomoyoUser>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        foreach (var role in TomoyoStarterData.Roles)
        {
            builder.Entity<TomoyoRole>().HasData(role);
        }
    }
}